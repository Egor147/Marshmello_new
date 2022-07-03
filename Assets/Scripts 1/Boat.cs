using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float DiveSpeed, RotationAngle,Speed;
    public bool Player_heare;
    private Transform tr;

    private bool already = false;


    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void FixedUpdate(){
        if (Player_heare){
            rb.isKinematic = false;
            Go();
        }
        else{
            rb.isKinematic = true;
        }
    }

    void Go(){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(inputX*Speed,DiveSpeed,inputZ*-Speed);
        tr.localPosition = new Vector3(0,0.828f,0);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            if (!already){
                Rigidbody rb_player = other.gameObject.GetComponent<Rigidbody>();
                rb_player.constraints = RigidbodyConstraints.FreezeRotation;
                rb_player.mass = 0;
                rb_player.useGravity = false;
                tr = other.gameObject.GetComponent<Transform>();
                tr.SetParent(this.gameObject.transform);
                tr.gameObject.GetComponent<PlayerController>().On_boat = true;
                Player_heare = true;
                already = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector3(0,0,0);
            //Player_heare = false;
            //rb.useGravity = false;
        }
    }
}
