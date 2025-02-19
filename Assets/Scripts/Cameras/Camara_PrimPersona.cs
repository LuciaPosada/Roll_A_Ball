using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_PrimPersona : MonoBehaviour {
    // Objecto que vamos a segir con la camara
    public GameObject player; 
    // Sensibilidad del raton
    public float mouseSensitivity = 100f;
    // valor acumulativo de rotacion en el eje y
    private float yRotation = 0f;
    void Start(){

        // Orientación inicial de la cámara a (0, 0, 0)
        Vector3 initialRotation = Vector3.zero; 
        transform.rotation = Quaternion.Euler(initialRotation);

        // Establece la rotación horizontal inicial
        yRotation = initialRotation.y;
    }

    void Update(){
        // Obtiene los movimientos del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Gira la cámara en el eje Y
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position;
    }
}
