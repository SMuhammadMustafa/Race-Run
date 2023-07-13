using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PathFollower pathFollower;
    public float HP = 500f; 

    void Start()
    {
        pathFollower.speed = HP * 0.04f;     
    }
}
