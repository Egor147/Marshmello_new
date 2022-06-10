using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comforka : MonoBehaviour
{
    private Renderer rend;
    private Color StartColor, EndColor;
    [SerializeField] private float Step;
    private float t;
    private bool ready = true;
    public bool  Go;
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;

    void Start(){
        rend = gameObject.GetComponent<Renderer>();
        rend.material.color = Color.black;
        StartColor = Color.black;
        EndColor = Color.red;
        Fire = transform.GetChild(0).gameObject;
    }

    void Update(){
        if (Go && Vector3.Distance(transform.position, player.transform.position) > distance){
            Go = false;
        }
        if (Go || (!Go && rend.material.color != Color.black)){
            if (t >= 0.8f || rend.material.color == EndColor){
                ready = false;
                t=0;
                if (EndColor == Color.red)
                    Fire.SetActive(true);
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

    void OnTriggerStay(Collider other){

        if (other.gameObject.CompareTag("Player") && ((StartColor == Color.red && t <= 0.1f) || (EndColor == Color.red && t >= 0.6f)))
            PlayerController.GameOver = true;
    }

    IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
        Fire.SetActive(false);
    }
}
