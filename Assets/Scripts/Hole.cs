using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class Hole : MonoBehaviour
{
    private AudioSource audioSource;
    private int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == playerLayer)
        {
            Debug.Log("dæjå");
            audioSource.Play();
            other.gameObject.GetComponent<Player>().StartFalling();
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerLayer = LayerMask.NameToLayer("Player");
    }
}