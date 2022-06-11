using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBoat : MonoBehaviour
{
    [SerializeField] private Vector3 NewCameraRotation;

    [SerializeField] private Vector3 NewOffset;

    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Player")){

            CameraMovement.Rotat = NewCameraRotation;

            CameraMovement.Offset = NewOffset;

        }


    }



}