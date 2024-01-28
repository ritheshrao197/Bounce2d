using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;

public float smoothSpeed = 1f;

void LateUpdate()
{
    if (player != null)
    {
            playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

}
