using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(BoxCollider))]
public class WumpusRoom : MonoBehaviour
{
    public Transform wumpusPoint;
    public Wumpus wumpus;
    public TeleportationProvider tp;
    private int playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            var request = new TeleportRequest();
            var origin = other.transform.parent.parent;
            request.destinationPosition = new Vector3(wumpusPoint.position.x, origin.position.y, wumpusPoint.position.z);
            request.destinationRotation = wumpusPoint.rotation;
            request.matchOrientation = MatchOrientation.TargetUpAndForward;
            tp.QueueTeleportRequest(request);
            wumpus.StartMoving();
        }
    }

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
}
