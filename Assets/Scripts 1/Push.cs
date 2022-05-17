using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push : MonoBehaviour
{
    [SerializeField] private GameObject Canv;
    [SerializeField] private Text txt;
    [SerializeField] private float t;
    Rigidbody rb;
    bool Clicked = false;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("CanPush")){
            rb = other.gameObject.GetComponent<Rigidbody>();
            Canv.SetActive(true);
            txt.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("CanPush")){
            if (Input.GetButtonDown("Push")){
                if (!Clicked){
                    Clicked = true;
                    if(other.gameObject.transform.parent == null){
                        txt.text = "Нажмите x, чтобы отпустить";
                        PlayerController.Pushing = true;
                        other.gameObject.transform.SetParent(gameObject.transform);
                    }
                    else{
                        txt.text = "Нажмите x, чтобы тащить";
                        PlayerController.Pushing = false;
                        other.gameObject.transform.SetParent(null);
                    }
                    StartCoroutine(Waiting(t));
                }
            }
        }
    }

    IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Clicked = false;
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("CanPush")){
            txt.gameObject.SetActive(false);
            Canv.SetActive(false);
        }
    }
}
