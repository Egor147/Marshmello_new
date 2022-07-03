using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] GameObject Drop_prefab;
    public static bool Go;
    private bool already = false;

    void Update()
    {
        if (Go && !already){
            StartCoroutine(Spawn());
            already = true;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,2));
        Instantiate(Drop_prefab, transform.position, Quaternion.identity);
        already = false;
    }
}
