using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBump : MonoBehaviour
{
    public ParticleSystem particles;
    public GameManager gameManager;
    public AudioSource sound;
    public float hpDeduct = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particles.Play();
            sound.Play();
            gameManager.ChangePlayerHP(-hpDeduct);
        }
    }
}
