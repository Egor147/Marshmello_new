using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]private float DiveSpeed, RotationAngle;
    [SerializeField]private GameObject Player;
    [SerializeField]private float Speed;
    private bool Player_heare;

    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void FixedUpdate(){
        if (Player_heare)
            Go();
    }

    void Go(){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(inputX*Speed,DiveSpeed,inputZ*-Speed);
        //Player.gameObject.GetComponent<Rigidbody>().velocity = rb.velocity;
        //transform.GetChild(0).TransformPoint(new Vector3 (0,0,0));
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            //PlayerController.CanMove = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().mass = 0;
            Player_heare = true;
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            //Debug.Log("Pau");
            //other.gameObject.GetComponent<Rigidbody>().velocity = rb.velocity;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector3(0,0,0);
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
