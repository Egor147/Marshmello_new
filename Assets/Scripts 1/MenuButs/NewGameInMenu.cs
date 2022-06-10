using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameInMenu : MonoBehaviour
{
    [SerializeField] private GameObject TurnOff, TurnOn;

    public void Click(){
        TurnOn.SetActive(true);
        TurnOff.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
