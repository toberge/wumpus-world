using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new private Rigidbody rigidbody;
    private int holeLayer;
    private int wumpusLayer;
    private int windLayer;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.layer);
        if (other.transform.gameObject.layer == holeLayer)
        {
            Debug.Log("dæjå");
            rigidbody.isKinematic = false;
        }
        else if (other.transform.gameObject.layer == windLayer)
        {
            Debug.Log("wind's howlin'");
            other.transform.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.layer == windLayer)
        {
            Debug.Log("wind's howlin'");
            other.transform.gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        holeLayer = LayerMask.NameToLayer("Hole");
        wumpusLayer = LayerMask.NameToLayer("Wumpus");
        windLayer = LayerMask.NameToLayer("Wind");
        Debug.Log(holeLayer);
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
