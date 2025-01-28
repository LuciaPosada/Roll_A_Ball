using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosterTrigger : MonoBehaviour {
    
    public float aumentoVelocidad;
    public float duracion;
    public PlayerController player;
    private void OnTriggerEnter(Collider colision) {

        if(colision.CompareTag("Player")){
            player.speed += aumentoVelocidad;
        }
    }
}
