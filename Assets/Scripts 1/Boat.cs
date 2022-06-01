using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]private float DiveSpeed, RotationAngle;
    //private bool already = false;

    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            //already = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Vector3 PlayerRigidbodyVelocity = other.gameObject.GetComponent<Rigidbody>().velocity;
            rb.velocity = new Vector3(PlayerRigidbodyVelocity.x, DiveSpeed * Time.deltaTime, PlayerRigidbodyVelocity.z);
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector3(0,0,0);
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
