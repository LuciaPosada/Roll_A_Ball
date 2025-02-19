using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTrigger : MonoBehaviour {

    public float fuerzaEmpujon = 25f; 

    private void OnCollisionEnter(Collision colision){

        if (colision.gameObject.CompareTag("Player")){
            Rigidbody player = colision.gameObject.GetComponent<Rigidbody>();
            if(player != null){
                Vector3 empuje = transform.right;
                player.AddForce(empuje*fuerzaEmpujon*-1,ForceMode.Impulse);
            }
        }
    }

}