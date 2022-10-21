using UnityEngine;

public class Player : MonoBehaviour
{
    private int holeLayer;
    private int wumpusLayer;
    private int smellLayer;
    private int windLayer;
    public Transform origin;
    public Transform offset;

    public void StartFalling()
    {
        // Add physics to offset (camera can't be adjusted manually)
        var offsetBody = offset.gameObject.GetComponent<Rigidbody>();
        var offsetCollider = offset.gameObject.GetComponent<BoxCollider>();
        offsetCollider.center = transform.position;
        offsetBody.isKinematic = false;
    }

    void Start()
    {
        holeLayer = LayerMask.NameToLayer("Hole");
        wumpusLayer = LayerMask.NameToLayer("Wumpus");
    }
}
