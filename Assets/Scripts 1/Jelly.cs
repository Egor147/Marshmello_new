using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
   [SerializeField] float Ratio;

   void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("Player")){
         var rb = other.gameObject.GetComponent<Rigidbody>();
        rb.velocity =  new Vector3(rb.velocity.x, Ratio, rb.velocity.z);//AddForce(new Vector3(0,Ratio,0), ForceMode.Impulse);
         PlayerController.Jumping = true;
      }
   }
}
