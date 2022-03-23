using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
  
  void LateUpdate () 
  {
      transform.position = new Vector3 (player.position.x + offset.x,4f, -10f); // Camera follows the player with specified offset position
  }
}
