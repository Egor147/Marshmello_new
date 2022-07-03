using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_out : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("Player")){
            Transform tr = other.gameObject.GetComponent<Transform>();
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = 1;
            Vector3 pos = tr.position;
            tr.parent.GetComponent<Boat>().Player_heare = false;
            tr.SetParent(null);
            other.gameObject.GetComponent<PlayerController>().On_boat = false;
            Debug.Log(other.gameObject.GetComponent<PlayerController>().On_boat);
            tr.position = pos;
            rb.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
