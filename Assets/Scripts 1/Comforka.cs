using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comforka : MonoBehaviour
{
    private Renderer rend;
    private Color StartColor, EndColor;
    [SerializeField] private float t, Step;
    private bool ready = true;
    [SerializeField] private GameObject DeadMenu;

    void Start(){
        rend = gameObject.GetComponent<Renderer>();
        StartColor = Color.black;
        EndColor = Color.red;
    }

    void Update(){
        if (t >= Step*200){
            ready = false;
            t=0;
            Color temp = StartColor;
            StartColor = EndColor;
            EndColor = temp;
            StartCoroutine(Waiting(3));
        }

        if (ready){
            Change_color(rend, StartColor, EndColor);
        }
    }
    

    void Change_color(Renderer rend, Color startColor, Color endColor){
        t+= Step;
        rend.material.color = Color.Lerp (rend.material.color, endColor,  t);
    }

    void OnTriggerStay(Collider other){

        if (other.gameObject.CompareTag("Player") && StartColor == Color.red && t == 0){
            DeadMenu.SetActive(true);
            DeadMenu.GetComponent<Transform>().Find("Dead").gameObject.SetActive(true);
            PlayerController.GameOver = true;
        }
    }


    IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
    }
}
