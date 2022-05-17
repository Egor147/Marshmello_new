using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    [SerializeField] private GameObject Canv;

    public void Click(){
        Canv.GetComponent<Transform>().Find("Pause").gameObject.SetActive(false);
        Canv.SetActive(false);
        Time.timeScale = 1f;
        PlayerController.GameOver = false;
    }
}
