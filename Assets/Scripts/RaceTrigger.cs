using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrigger : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))     // Before race starts, turn off player movement and center player
        {
            playerMovement.enabled = false;
            other.transform.localPosition = new Vector3(0f, other.transform.localPosition.y, other.transform.localPosition.x);
        }
    }
}
