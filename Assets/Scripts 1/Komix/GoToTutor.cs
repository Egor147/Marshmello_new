using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTutor : MonoBehaviour
{

    [SerializeField] private GameObject TurnOff, TurnOn;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
        Click();
        }
    }

    void Click(){
        TurnOn.SetActive(true);
            TurnOff.SetActive(false);
    }
}
