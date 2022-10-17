using UnityEngine;

public class Wumpus : MonoBehaviour
{
    private Vector3 speed = Vector3.zero;
    private Animator animator;
    public float speedMultiplier = 2f;
    public Transform wumpusPoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartMoving()
    {
        speed = Vector3.back * 0.032f * speedMultiplier;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (transform.position.z > wumpusPoint.position.z + 4)
        {
            transform.position += speed;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0)
        {
            animator.enabled = false;
        }
    }
}
