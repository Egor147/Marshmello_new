using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    [SerializeField] private List<GameObject> Toasts = new List<GameObject>();
    [SerializeField] private float JumpPower;
    private bool came = false;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player") && !came){
            came = true;
            for(int i = 0; i < Toasts.Count; i++){
                Rigidbody rb = Toasts[i].GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0,JumpPower,0), ForceMode.Impulse);
                Toasts[i].GetComponent<Toast>().Go = true;
            }
        }
    }
}
