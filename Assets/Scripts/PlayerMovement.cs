using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float yPosition = 0.065f;
    public float xRange = 1;   

    float xPosition;

    float initialPosition;
    float initialPlayerPosition;

    void Update()
    {
        // Get initial mouse/touch and player position
        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = Input.mousePosition.x;
            initialPlayerPosition = player.localPosition.x;
        }

        // Add dragged amount to player position
        if (Input.GetMouseButton(0))
        {
            xPosition = (Input.mousePosition.x - initialPosition) / initialPosition;

            player.localPosition = new Vector3(Mathf.Clamp(initialPlayerPosition + (xPosition * xRange), -xRange, xRange), yPosition, 0f);
        }
    }
}
