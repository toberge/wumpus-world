using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : MonoBehaviour
{
    private Vector3 speed = Vector3.zero;

    public void StartMoving()
    {
        speed = Vector3.back * 0.032f;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        transform.position += speed;
    }
}
