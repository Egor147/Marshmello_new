using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_out : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().On_boat = false;
            //PlayerController.CanMove = true;
            //other.gameObject.transform.SetParent(null);
            Debug.Log(other.gameObject.GetComponent<PlayerController>().On_boat);
        }
    }
}
