using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private GameObject MyDown;
    public bool Go = false;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Go){
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting(){
        yield return new WaitForSeconds(1);
        MyDown.GetComponent<Down>().Go = true;
        Destroy(gameObject);
    }
}
