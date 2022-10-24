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
            var origin = other.transform.parent.parent;
            var destination = new Vector3(wumpusPoint.position.x, origin.position.y, wumpusPoint.position.z);
            other.gameObject.GetComponent<Player>().TeleportTo(destination, wumpusPoint.rotation);
            wumpus.StartMoving();
        }
    }

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
}
