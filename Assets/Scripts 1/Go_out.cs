using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_out : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("Player")){
            //other.gameObject.transform.SetParent(null);
            other.gameObject.GetComponent<PlayerController>().On_boat = false;
            Debug.Log(other.gameObject.GetComponent<PlayerController>().On_boat);
        }
    }
}
