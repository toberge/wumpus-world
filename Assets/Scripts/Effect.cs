using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class Effect : MonoBehaviour
{
    private AudioSource audioSource;
    private int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            audioSource.Stop();
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerLayer = LayerMask.NameToLayer("Player");
    }
}
