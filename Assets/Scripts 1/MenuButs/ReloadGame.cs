using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    [SerializeField] GameObject TurnOff;
    [SerializeField] GameObject TurnOn;
    public void Click(){
        TurnOff.SetActive(false);
        TurnOn.SetActive(true);
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene("Game");
    }
}
