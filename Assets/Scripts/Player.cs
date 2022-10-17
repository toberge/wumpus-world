using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new private Rigidbody rigidbody;
    private int holeLayer;
    private int wumpusLayer;
    private int smellLayer;
    private int windLayer;
    public Transform wumpusPoint;
    public Wumpus wumpus;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.layer);
        if (other.transform.gameObject.layer == holeLayer)
        {
            Debug.Log("dæjå");
            rigidbody.isKinematic = false;
            other.transform.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (other.transform.gameObject.layer == windLayer || other.transform.gameObject.layer == smellLayer)
        {
            other.transform.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (other.transform.gameObject.layer == wumpusLayer)
        {
            transform.position = new Vector3(wumpusPoint.position.x, transform.position.y, wumpusPoint.position.z);
            transform.Rotate(0, Vector3.Angle(new Vector3(transform.forward.x, 0, transform.forward.z), Vector3.forward), 0);
            //transform.forward = Quaternion.Euler(0, Vector3.Angle(new Vector3(transform.forward.x, 0, transform.forward.z), Vector3.forward), 0);
            wumpus.StartMoving();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.layer == windLayer || other.transform.gameObject.layer == smellLayer)
        {
            other.transform.gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    void Start()
    {
        holeLayer = LayerMask.NameToLayer("Hole");
        wumpusLayer = LayerMask.NameToLayer("Wumpus");
        smellLayer = LayerMask.NameToLayer("Smell");
        windLayer = LayerMask.NameToLayer("Wind");
        rigidbody = GetComponent<Rigidbody>();
    }
}
