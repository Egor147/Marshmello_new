using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]private List<GameObject> MyDown = new List<GameObject>();
    public static bool Go = false;
    [SerializeField] private float Wait_time;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            StartCoroutine(GoDown());
        }
    }

    IEnumerator GoDown(){
        for (int i=0; i<MyDown.Count;i++){
            yield return new WaitForSeconds(Wait_time);
            MyDown[i].GetComponent<Down>().Go = true;
        }
    }
}
