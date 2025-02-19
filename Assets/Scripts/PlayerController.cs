using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour{
   // Rigidbody of the player.
   private Rigidbody rb; 
   private int count;
   // Movement along X and Y axes.
   private float movementX;
   private float movementY;

   // Speed at which the player moves.
   public float speed; 

   public TextMeshProUGUI countText;

   public GameObject winTextObject;

   public Transform cameraTransform;

   private Vector3 dir;

   // Start is called before the first frame update.
   void Start(){
      // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);

        dir = Vector3.zero;
   }
 
   // This function is called when a move input is detected.
   void OnMove(InputValue movementValue){
      // Convert the input value into a Vector2 for movement.
      Vector2 movementVector = movementValue.Get<Vector2>();

      // Store the X and Y components of the movement.
      movementX = movementVector.x; 
      movementY = movementVector.y; 
   }

   // FixedUpdate is called once per fixed frame-rate frame.
   private void FixedUpdate(){
      // Calcula la dirección de movimiento en base a la cámara
      Vector3 forward = cameraTransform.forward; 
      Vector3 right = cameraTransform.right; 
/**
      dir.x = -Input.acceleration.y;
      dir.z = Input.acceleration.x;
      if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
      dir *= Time.deltaTime;
      transform.Translate(dir * speed);
**/

      // Create a 3D movement Vector
      Vector3 movement = forward * movementY + right * movementX;
      movement.Normalize();

      //Apply force to the Rigidbody to move the player.
      rb.AddForce(movement * speed); 
      Debug.Log(speed);
   }

   // Check if the object the player collided with has the "PickUp" tag.
   void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("PickUp")){
         // Deactivate the collided object (making it disappear).
         other.gameObject.SetActive(false);

         count += 1;

         SetCountText();
      }
   }

   void SetCountText(){
      countText.text = "Count: " + count.ToString();

      if(count >= 38){
         winTextObject.SetActive(true);
         Destroy(GameObject.FindGameObjectWithTag("Enemy"));
      }
   }
   
   private void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.CompareTag("Enemy")) {

         Animator enemigoAnimator = FindObjectOfType<EnemyMovement>().GetComponent<Animator>();

         if(enemigoAnimator.GetCurrentAnimatorStateInfo(0).IsName("Escapar")){
            enemigoAnimator.SetTrigger("Tocado");
         }else{
            // Destroy the current object
            Destroy(gameObject); 
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
         }
      }
   }
}