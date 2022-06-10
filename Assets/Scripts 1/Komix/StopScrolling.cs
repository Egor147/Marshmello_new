using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopScrolling : MonoBehaviour
{
    [SerializeField] private GameObject Scroll;

    void Update()
    {
        if (this.gameObject.GetComponent<RectTransform>().localPosition.y >=5000){
            Scroll.SetActive(false);
        }
    }
}
