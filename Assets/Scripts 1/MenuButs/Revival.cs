using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revival : MonoBehaviour
{
    public void Click(){
        SceneManager.LoadScene("Game");
    }
}
