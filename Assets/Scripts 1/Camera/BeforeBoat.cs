using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBoat : MonoBehaviour
{
    [SerializeField] private Vector3 NewCameraRotation;
    [SerializeField] private Vector3 NewOffset;
    [SerializeField] private GameObject camera;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            CameraMovement.Rotat = NewCameraRotation;
            CameraMovement.Offset = NewOffset;
        }
    }
}
