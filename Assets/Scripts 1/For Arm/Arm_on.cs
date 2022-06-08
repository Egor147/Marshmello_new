using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_on : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private Vector3 Offset;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            arm.transform.position = new Vector3(other.gameObject.transform.position.x+Offset.x,other.gameObject.transform.position.y+Offset.y,1.4358f);
            arm.SetActive(true);
        }
    }
}
