using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afm_off : MonoBehaviour
{
    [SerializeField] private GameObject arm;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            arm.SetActive(false);
        }
    }
}
