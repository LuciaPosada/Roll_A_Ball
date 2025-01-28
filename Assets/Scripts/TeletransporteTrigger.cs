using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransporteTrigger : MonoBehaviour {
    
    public Transform destino;

    private void OnTriggerEnter(Collider colision) {
        if(colision.CompareTag("Player")){
            colision.transform.position = destino.position;
        }
    }
}
