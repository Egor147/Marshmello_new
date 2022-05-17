using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 CheckpointCoord;

    void Start() => CheckpointCoord = transform.position;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Checkpoint")){
            PlayerPrefs.SetFloat("XCoord",gameObject.transform.position.x);
            PlayerPrefs.SetFloat("YCoord",gameObject.transform.position.y);
            PlayerPrefs.SetFloat("ZCoord",gameObject.transform.position.z);
        }
    }
}
