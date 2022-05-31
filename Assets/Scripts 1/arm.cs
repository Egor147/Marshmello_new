using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private bool caught = false;
    private GameObject target;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (!caught)
            rb.velocity = new Vector3(Speed, rb.velocity.y, rb.velocity.z);
        else{
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Mathf.Abs(Speed) * 10 * Time.deltaTime);
            //transform.position += (target.transform.position - transform.position).normalized * Mathf.Abs(Speed) * Time.deltaTime;
        }
    }


    /*void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player")){
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, Speed * 10 * Time.deltaTime);
        }
    }*/

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector3(0,0,0);
            target = other.gameObject;
            caught = true;
        }
    }

}
