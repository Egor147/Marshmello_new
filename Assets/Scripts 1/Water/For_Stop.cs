using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_Stop : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            WaterDrop.Go = false;
        }
    }
}
