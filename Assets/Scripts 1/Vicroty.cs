using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vicroty : MonoBehaviour
{
    [SerializeField] private GameObject VictoryMenu;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Cursor.visible = true;
            Time.timeScale = 0;
            VictoryMenu.SetActive(true);
            VictoryMenu.GetComponent<Transform>().Find("Victory").gameObject.SetActive(true);
        }
    }
}
