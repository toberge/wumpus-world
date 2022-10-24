using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private int holeLayer;
    private int wumpusLayer;
    private int smellLayer;
    private int windLayer;
    public Transform origin;
    public Transform offset;
    public Transform startPoint;
    public TeleportationProvider tp;
    public GameObject deathScreen;
    public GameObject victoryScreen;

    public delegate void Event();
    public Event onReset;

    public void StartFalling()
    {
        // Add physics to offset (camera can't be adjusted manually)
        var offsetBody = offset.gameObject.GetComponent<Rigidbody>();
        var offsetCollider = offset.gameObject.GetComponent<BoxCollider>();
        offsetCollider.center = transform.position;
        offsetBody.isKinematic = false;
    }

    public void TeleportTo(Vector3 position, Quaternion rotation)
    {
        var request = new TeleportRequest();
        request.destinationPosition = position;
        request.destinationRotation = rotation;
        request.matchOrientation = MatchOrientation.TargetUpAndForward;
        tp.QueueTeleportRequest(request);
    }

    public void Reset()
    {
        var offsetBody = offset.gameObject.GetComponent<Rigidbody>();
        offsetBody.isKinematic = true;
        offset.position = startPoint.position;
        TeleportTo(startPoint.position, startPoint.rotation);
        onReset.Invoke();
    }

    public void Die()
    {
        deathScreen.SetActive(true);
    }

    public void Win()
    {
        victoryScreen.SetActive(true);
    }

    void Start()
    {
        holeLayer = LayerMask.NameToLayer("Hole");
        wumpusLayer = LayerMask.NameToLayer("Wumpus");
    }
}
