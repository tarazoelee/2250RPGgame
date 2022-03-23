using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        var position = transform.position;
        // overwrite only the X component
        position.x = player.transform.position.x + 9f;
        // assign the new position back
        transform.position = position;
    }
}
