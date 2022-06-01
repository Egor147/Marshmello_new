using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject TutorialCanvas;

    void Start() => PlayerController.GameOver = true;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            TutorialCanvas.GetComponent<Transform>().Find("TutorialImage").gameObject.SetActive(false);
            TutorialCanvas.SetActive(false);
            PlayerController.GameOver = false;
            Destroy(this);
        } 
    }

}
