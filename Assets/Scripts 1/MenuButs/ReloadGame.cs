using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public void Click(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
    }
}
