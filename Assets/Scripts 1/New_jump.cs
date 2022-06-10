using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_jump : MonoBehaviour
{
    public float Ratio;

   void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("Player")){
        PlayerController.JumpPower = Ratio;
      }
   }
}
