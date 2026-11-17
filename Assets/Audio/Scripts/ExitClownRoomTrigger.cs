using System;
using UnityEngine;

public class ExitClownRoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided  with " + other.name);
    }
}
