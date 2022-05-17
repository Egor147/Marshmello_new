using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    [SerializeField] private GameObject DeadMenu;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            DeadMenu.SetActive(true);
            DeadMenu.GetComponent<Transform>().Find("Dead").gameObject.SetActive(true);
            PlayerController.GameOver = true;
        }
        
    }
}
