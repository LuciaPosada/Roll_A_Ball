using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_World : MonoBehaviour {

    public Transform target; 
    public float speed;

    void Update(){
        transform.LookAt(target);
        transform.Translate(Vector3.right * speed);
        //transform.RotateAround(target.position, Vector3.up, speed);
    }
}
