using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == playerLayer)
        {
            other.gameObject.GetComponent<Player>().Die();
        }
    }

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
}
