using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject TutorialCanvas;

    void Start() => Time.timeScale = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            TutorialCanvas.GetComponent<Transform>().Find("TutorialImage").gameObject.SetActive(false);
            TutorialCanvas.SetActive(false);
            Time.timeScale = 1f;
            Destroy(this);
        } 
    }

}
