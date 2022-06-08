using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{

    Rigidbody rb;
    private GameObject[] MyDown;
    public static bool Go = false;
    [SerializeField] private float Wait_time;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        MyDown = GameObject.FindGameObjectsWithTag("tost");
    }

    void Update()
    {
        if (Go){
            StartCoroutine(GoDown());
        }
    }

    IEnumerator GoDown(){
        for (int i=0; i<MyDown.Length;i++){
            yield return new WaitForSeconds(Wait_time);
            MyDown[i].GetComponent<Down>().Go = true;
        }
    }
}
