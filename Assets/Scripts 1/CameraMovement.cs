using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [Header(" ")]
    [SerializeField] private Vector3 distanceFromPlayer;
    [SerializeField] private Vector3 Rotation;

    //private void Start() => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Rotation),1);
    private void FixedUpdate() => CameraMove();

    private void CameraMove()
    {
        Vector3 positionToGo = player.transform.position + distanceFromPlayer;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, 0.125f);
        transform.position = smoothPosition;
    }
}
