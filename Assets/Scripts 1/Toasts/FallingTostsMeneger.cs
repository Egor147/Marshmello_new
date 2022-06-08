using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTostsMeneger : MonoBehaviour
{
    [SerializeField] private GameObject[] Tosts;
    // Start is called before the first frame update
    void Start()
    {
        Tosts = GameObject.FindGameObjectsWithTag("tost");
        Debug.Log(Tosts.Length);
    }

    void OnTriggerEnter(Collider other){
        
        if (other.gameObject.CompareTag("Player")){
            for (int i=0; i< Tosts.Length; i++){
                Tosts[i].GetComponent<Down>().Go = true;
            }
        }
    }
}
