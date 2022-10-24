using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : MonoBehaviour
{
    private int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == playerLayer)
        {
            other.gameObject.GetComponent<Player>().Win();
        }
    }

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
}
