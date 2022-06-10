using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    private bool already = false;

    void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player") && !already){
            Debug.Log("LOH");
            PlayerController.GameOver = true;
            already = true;
        }
    }
}
