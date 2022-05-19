using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comforka : MonoBehaviour
{
    private Renderer rend;
    private Color StartColor, EndColor;
    [SerializeField] private float t, Step;
    private bool ready = true;
    public bool  Go;
    [SerializeField] private GameObject Fire;

    void Start(){
        rend = gameObject.GetComponent<Renderer>();
        rend.material.color = Color.black;
        StartColor = Color.black;
        EndColor = Color.red;
        Fire = transform.GetChild(0).gameObject;
    }

    void Update(){
        if (Go || (!Go && rend.material.color != Color.black)){
            /*if (!Go){
                Fire.SetActive(false);
            }*/
            if (t >= 1 || rend.material.color == EndColor){
                ready = false;
                t=0;
                if (EndColor == Color.red){
                    Fire.SetActive(true);
                }
                Color temp = StartColor;
                StartColor = EndColor;
                EndColor = temp;
                StartCoroutine(Waiting(3));
            }

            if (ready){
                Change_color(rend, StartColor, EndColor);
            }
        }
    }

    void Change_color(Renderer rend, Color startColor, Color endColor){
        t += Step*Time.deltaTime;
        rend.material.color = Color.Lerp (rend.material.color, endColor,  t);
    }

    /*void OnTriggerStay(Collider other){

        if (other.gameObject.CompareTag("Player") && StartColor == Color.red && t == 0){
            DeadMenu.SetActive(true);
            DeadMenu.GetComponent<Transform>().Find("Dead").gameObject.SetActive(true);
            PlayerController.GameOver = true;
        }
    }*/

    IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
        Fire.SetActive(false);
    }
}
