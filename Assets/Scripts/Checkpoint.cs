using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource goodSound;
    public AudioSource badSound;

    public float rightHP;
    public float leftHP;

    private void OnTriggerEnter(Collider other)
    {
        // Check if trigger collided with player
        if (other.CompareTag("Player"))
        {
            
            if (other.transform.localPosition.x > 0f)    // If player is on the right side, add right HP and play appropriate sound
            {
                if (rightHP > 0)
                {
                    goodSound.Play();
                }
                else
                {
                    badSound.Play();
                }
                gameManager.ChangePlayerHP(rightHP);
            }
            else    // If player is on the left side, add left HP and play appropriate sound
            {
                if (leftHP > 0)
                {
                    goodSound.Play();
                }
                else
                {
                    badSound.Play();
                }
                gameManager.ChangePlayerHP(leftHP);
            }
        }
    }
}
