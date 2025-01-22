using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_2 : MonoBehaviour{
    // Update is called once per frame
    public float rotationSpeed = 100f;

    public bool rotateClockwise = true;

    void Update(){

        float direction = rotateClockwise ? 1f : -1f;

        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0, Space.World);
    }
}
