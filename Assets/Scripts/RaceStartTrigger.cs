using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartTrigger : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyClone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))    // When race starts, turn on enemy car so that it travels the path
        {
            enemyClone.SetActive(false);
            enemy.SetActive(true);
        }
    }
}
