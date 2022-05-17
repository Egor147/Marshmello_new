using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    private Rigidbody rb;
      [SerializeField] private float SpeedFall;

    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if (other.gameObject.transform.position.y>gameObject.transform.position.y && Mathf.Abs(other.gameObject.transform.position.x - gameObject.transform.position.x) < gameObject.transform.localScale.x/2)
                rb.velocity =new Vector3 (0,SpeedFall,0);
        }
    }
}
