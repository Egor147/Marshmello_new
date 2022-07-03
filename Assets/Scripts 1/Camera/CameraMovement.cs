using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [Header(" ")]
    [SerializeField] private Vector3 distanceFromPlayer;
    [SerializeField] private Vector3 Rotation;
    public static Vector3 Offset, Rotat;

    void Start(){
        Offset = distanceFromPlayer;
        Rotat = Rotation;
    }

    private void FixedUpdate() => CameraMove();
    private void CameraMove()
    {
        Vector3 positionToGo = player.transform.position + Offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, 0.125f);
        transform.position = smoothPosition;
        CameraRotation();
    }

    private void CameraRotation(){
        Quaternion Rotation_Q = Quaternion.Euler(Rotat);

        transform.rotation = Quaternion.Lerp(transform.rotation, Rotation_Q, 10 * Time.deltaTime);
    }
}
