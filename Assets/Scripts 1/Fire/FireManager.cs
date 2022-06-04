using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Fire = new List<GameObject>();
    [SerializeField]private List<int> index = new List<int>();
    private bool Start = false, NewIteration = true;
    [SerializeField]private int NumberOfComforks;
    [SerializeField]private float TimeOfFire;

    void Update(){
        if (Start && NewIteration){
            NewIteration = false;
            for (int i = 0; i < NumberOfComforks; i++){
                int f = (int)Random.Range(1,Fire.Count+1);
                Debug.Log(f);
                if (!Fire[f-1].GetComponent<Comforka>().Go){
                    Fire[f-1].GetComponent<Comforka>().Go = true;
                    index.Add(f-1);
                }
                else
                    i--;
            }
            StartCoroutine(WaitingForStopFire(TimeOfFire));
        }
    }

    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("Player")){
            Start = true;
        }
    }

    /*IEnumerator WatingForFire(float WaitingTime){
        yield return new WaitForSeconds(WaitingTime);
        NewIteration = true;
    }*/

    IEnumerator WaitingForStopFire(float WaitingTime){
        yield return new WaitForSeconds (WaitingTime);
        for (int i = 0; i<index.Count;i++){
            Fire[index[i]].GetComponent<Comforka>().Go = false;
        }
        index.Clear();
        NewIteration = true;
    }
}
