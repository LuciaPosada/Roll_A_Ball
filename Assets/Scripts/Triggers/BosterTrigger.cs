using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosterTrigger : MonoBehaviour {
    public float aumentoVelocidad; 
    public float duracion; 

    private void OnTriggerEnter(Collider colision){

        if (colision.CompareTag("Player")){
            PlayerController player = colision.GetComponent<PlayerController>();
            StartCoroutine(Boost(player)); // Corrutina
        }
    }

    private IEnumerator Boost(PlayerController player){
        
        player.speed = player.speed * aumentoVelocidad;

        // Espera el tiempo del boost
        yield return new WaitForSeconds(duracion);

        player.speed = player.speed / aumentoVelocidad;
    }
}
