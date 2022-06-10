using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    [SerializeField] private List<GameObject> Toasts = new List<GameObject>();
    [SerializeField] private float JumpPower, wait_to_die;
    private bool came = false;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player") && !came){
            came = true;
            StartCoroutine(Wait_to_go_up());
            StartCoroutine(Waiting());
        }
    }
    
    IEnumerator Waiting(){
        yield return new WaitForSeconds(wait_to_die);
        for(int i = 0; i < Toasts.Count; i++){
            Destroy(gameObject);
        }
    }

    IEnumerator Wait_to_go_up(){
        for(int i = 0; i < Toasts.Count; i++){
            yield return new WaitForSeconds(0.05f);
            Rigidbody rb = Toasts[i].GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0,JumpPower,0), ForceMode.Impulse);
        }
        //Toast.Go = true;
    }
}
