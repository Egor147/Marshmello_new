using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_Start : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            WaterDrop.Go = true;
            //other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
