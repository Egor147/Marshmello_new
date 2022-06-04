using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player"))
            PlayerController.Slipper = true;
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player"))
            PlayerController.Slipper = false;
    }
}
