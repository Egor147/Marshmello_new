using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    [SerializeField] private bool caught = false;
    private Vector3 target;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (!caught)
            rb.velocity = new Vector3(Speed, rb.velocity.y, rb.velocity.z);
        else{
            transform.position = Vector3.MoveTowards(transform.position, target, Mathf.Abs(Speed) * 10 * Time.deltaTime);
            PlayerController.GameOver = true;
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
            target = new Vector3(other.gameObject.transform.position.x + 15f,  other.gameObject.transform.position.y + 1,  other.gameObject.transform.position.z-6.12f);
            caught = true;
        }
    }

}
