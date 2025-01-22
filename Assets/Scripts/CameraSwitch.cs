using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject firstPersonCamera; 
    public GameObject thirdPersonCamera; 
    public GameObject WorldCamera; 

    private void Start(){
        ActivateThirdPersonCamera(); 
    }

    private void Update(){
        // Cámara en primera persona, tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            ActivateFirstPersonCamera();
        }
        // Cámara en tercera persona, tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            ActivateThirdPersonCamera();
        }
        // Cámara del mundo, tecla 3
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            ActivateWorldViewCamera();
        }
    }

    private void ActivateFirstPersonCamera(){
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        WorldCamera.SetActive(false);
    }

    private void ActivateThirdPersonCamera(){
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        WorldCamera.SetActive(false);
    }

    private void ActivateWorldViewCamera(){
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(false);
        WorldCamera.SetActive(true);
    }

}
