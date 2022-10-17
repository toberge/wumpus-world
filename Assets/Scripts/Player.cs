using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private int holeLayer;
    private int wumpusLayer;
    private int smellLayer;
    private int windLayer;
    public Transform wumpusPoint;
    public Wumpus wumpus;
    public Transform origin;
    public Transform offset;
    public TeleportationProvider tp;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == holeLayer)
        {
            Debug.Log("dæjå");
            other.transform.gameObject.GetComponent<AudioSource>().Play();
            // Add physics to offset (camera can't be adjusted manually)
            var offsetBody = offset.gameObject.GetComponent<Rigidbody>();
            var offsetCollider = offset.gameObject.GetComponent<BoxCollider>();
            offsetCollider.center = transform.position;
            offsetBody.isKinematic = false;
        }
        else if (other.transform.gameObject.layer == windLayer || other.transform.gameObject.layer == smellLayer)
        {
            other.transform.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (other.transform.gameObject.layer == wumpusLayer)
        {
            var request = new TeleportRequest();
            request.destinationPosition = new Vector3(wumpusPoint.position.x, origin.position.y, wumpusPoint.position.z);
            request.destinationRotation = wumpusPoint.rotation;
            request.matchOrientation = MatchOrientation.TargetUpAndForward;
            tp.QueueTeleportRequest(request);
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
    }
}
