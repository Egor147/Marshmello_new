using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSpeed : MonoBehaviour
{
    private bool already = false;
    [SerializeField] private float SlowSpeed;
    private float StartSpeed;
    [SerializeField] private bool Eg;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            if (!already){
                StartSpeed = other.gameObject.GetComponent<PlayerController>().Speed;
                other.gameObject.GetComponent<PlayerController>().Speed=SlowSpeed;
                already = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().Speed=StartSpeed;
        }
        if (Eg){
            already = false;
        }
    }
}
