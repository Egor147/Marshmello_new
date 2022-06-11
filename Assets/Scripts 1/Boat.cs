using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]private float DiveSpeed, RotationAngle;
    [SerializeField]private GameObject Player;
    [SerializeField]private float Speed;
    //private bool already = false;
    private bool Player_heare;

    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void FixedUpdate(){
        if (Player_heare)
            Go();
    }

    void Go(){
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(inputX*Speed,DiveSpeed * Time.deltaTime,inputZ*-Speed);
        //transform.GetChild(0).TransformPoint(new Vector3 (0,0,0));
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            //already = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player"))
            Player_heare = true;
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector3(0,0,0);
            //Player_heare = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
            /*float inputZ = Input.GetAxis("Horizontal");
            float inputX = Input.GetAxis("Vertical");
            //Rotate = transform.rotation.eulerAngles +  Vector3.one * RotationAngle*inputZ;
            if (inputX<0)
                Rotation((RotationAngle*-inputZ + 180));
            else
                Rotation(RotationAngle*inputZ);
        }
    }

    void Rotation (float Rotation){
        transform.rotation = Quaternion.AngleAxis(Rotation, Vector3.up);
    }*/
}
