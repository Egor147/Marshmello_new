using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    public bool Go = false;
    Rigidbody rb;
    BoxCollider BC;

    void Start() { rb = gameObject.GetComponent<Rigidbody>(); BC = gameObject.GetComponent<BoxCollider>();}

    void Update(){
        if (Go){
            Fall();
        }
    }

    void Fall(){
        rb.useGravity = true;
    }


    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Ground")){
            Destroy(gameObject.GetComponent<Dead>());
            rb.mass = 100;
            BC.isTrigger = false;
        }
    }

}
