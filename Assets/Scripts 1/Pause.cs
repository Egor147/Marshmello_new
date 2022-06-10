using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject Canv;

    //private bool ActivatePause = false;
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !PlayerController.GameOver){
            ZeroTime();
        }
    }

    void ZeroTime(){
        if (!Canv.activeSelf){
            Cursor.visible = true;
            Canv.SetActive(true);
            if (!Canv.GetComponent<Transform>().Find("Pause").gameObject.activeSelf){
                Canv.GetComponent<Transform>().Find("Pause").gameObject.SetActive(true);
                //PlayerController.GameOver = true;
                Time.timeScale = 0;
            }
        } else{
            Cursor.visible = false;
            Canv.GetComponent<Transform>().Find("Pause").gameObject.SetActive(false);
            Canv.SetActive(false);
            Time.timeScale = 1f;
            //PlayerController.GameOver = false;
        }
    }
}
