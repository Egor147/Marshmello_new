using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomforkiEnd : MonoBehaviour
{
    [SerializeField] private GameObject KomforkiMeneger;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            FireManager.Should_start = false;
        }
    }
}
