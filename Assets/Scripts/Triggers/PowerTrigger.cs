using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTrigger : MonoBehaviour {

    public float duracion;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            
            Animator[] enemigosAnimator = FindObjectsOfType<Animator>();

            PowerUpManager.instance.ComenzarPowerUp(enemigosAnimator, duracion);             
        }
    }
}
