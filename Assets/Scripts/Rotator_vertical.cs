using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_vertical : MonoBehaviour{
    // Update is called once per frame
    public float rotationSpeed = 100f;

    public bool rotateClockwise = true;

    void Update(){

        float direction = rotateClockwise ? 1f : -1f;

        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime, Space.World);
    }  
}

