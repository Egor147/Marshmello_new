using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
   public float Ratio;

   void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("Player")){
         other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,Ratio,0), ForceMode.Impulse);
         PlayerController.Jumping = true;
      }
   }
}
