using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaceEndTrigger : MonoBehaviour
{
    private bool playerWin = false;
    private bool enemyWin = false;

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.end = true;
            if (!enemyWin)  // If player reaches before enemy
            {
                playerWin = true;
                gameManager.PlayerWin();
            }
            else
            {
                gameManager.PlayerLose();  
            }
        }

        if (other.CompareTag("Enemy"))
        {
            if (!playerWin) // If enemy reaches before player
            {
                enemyWin = true;
            }
        }
    }
}
