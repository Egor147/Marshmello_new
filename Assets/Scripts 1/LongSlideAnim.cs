using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSlideAnim : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float SpeedImpulse, TimeOfSlide;
    private bool already = false;

    void Start() => rb = gameObject.GetComponent<Rigidbody>();

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player") && !already){
            already = true;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            PlayerController.GameOver = true;
            PlayerController.Jumping = false;
            rb.AddForce(new Vector3(SpeedImpulse,0,0),ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(SpeedImpulse,0,0),ForceMode.Impulse);
            StartCoroutine(Waiting(TimeOfSlide));
        }
    }

    IEnumerator Waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayerController.GameOver = false;
    }
}
