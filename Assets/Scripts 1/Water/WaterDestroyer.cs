using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDestroyer : Dead
{
    void Update()
    {
        if (transform.position.y <= -2.78)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Ground")){
            PlayerController.GameOver = true;
        }
    }
}
