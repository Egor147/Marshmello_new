using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDestroyer : Dead
{
    [SerializeField] private AudioSource Kap;
    private bool alreadyy = false;

    void Update()
    {
        if (transform.position.y <= 0 && alreadyy == false){
            Kap.Play();
            alreadyy = true;
        }

        if (transform.position.y <= -2.78)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Boat")){
            PlayerController.GameOver = true;
        }
    }
}
