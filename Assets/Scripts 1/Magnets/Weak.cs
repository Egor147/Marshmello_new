using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;
    [SerializeField] private float timeToFall, SpeedFall;
    private bool PlayerOnIt = false;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
    }
    void Update(){
        if (PlayerOnIt){
            tr.position = new Vector3(tr.position.x,tr.position.y,tr.position.z + Random.Range(-0.05f,0.05f));
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player") && rb.isKinematic){
            PlayerOnIt = true;
            StartCoroutine(Fall(timeToFall));
        }
    }

    IEnumerator Fall(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayerOnIt = false;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
