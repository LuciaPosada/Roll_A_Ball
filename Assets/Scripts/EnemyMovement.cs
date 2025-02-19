using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    // Reference to the player's transform.
    public Transform player;
    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public string nombre;

    // Start is called before the first frame update.
    void Start() {
        // Get and store the NavMeshAgent component attached to this object.
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator =  GetComponent<Animator>();
    }

    // Update is called once per frame.
    void Update() {
        // If there's a reference to the player...
        if (player != null){   

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Morido")) {
                Debug.Log("Morido: "+nombre);
                Morir();
            } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Escapar")){
                Debug.Log("Escapar: "+nombre);
                Escapar();
            }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Perseguir")){
                // Set the enemy's destination to the player's current position.
                Debug.Log("Perseguir: "+nombre);
                Perseguir();
            }else{
                Debug.Log("Error: "+nombre);
            }
        }
    } 

    private void Morir(){
        navMeshAgent.isStopped = true;
        Destroy(gameObject); 
        return;
    }

    private void Perseguir(){
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position);
    }

    private void Escapar(){
        navMeshAgent.isStopped = false;
        Vector3 direction = transform.position - player.position;
        Vector3 fleePosition = transform.position + direction.normalized * navMeshAgent.speed;
        navMeshAgent.SetDestination(fleePosition);
    }
}
