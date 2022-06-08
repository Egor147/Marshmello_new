using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Fire;
    [SerializeField]private List<int> index = new List<int>();
    public static bool Should_start = false;
    private bool NewIteration = true;
    [SerializeField]private int NumberOfComforks;
    [SerializeField]private float TimeOfFire;

    void Start() => Fire = GameObject.FindGameObjectsWithTag("Komforka");

    void Update(){
        if (Should_start && NewIteration){
            NewIteration = false;
            for (int i = 0; i < NumberOfComforks; i++){
                int f = (int)Random.Range(1,Fire.Length+1);
                
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
            Should_start = true;
        }
    }

    IEnumerator WaitingForStopFire(float WaitingTime){
        yield return new WaitForSeconds (WaitingTime);
        for (int i = 0; i<index.Count;i++){
            Fire[index[i]].GetComponent<Comforka>().Go = false;
        }
        index.Clear();
        NewIteration = true;
    }
}
