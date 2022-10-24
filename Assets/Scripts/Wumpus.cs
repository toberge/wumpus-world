using UnityEngine;

public class Wumpus : MonoBehaviour
{
    private Vector3 speed = Vector3.zero;
    private Animator animator;
    public float speedMultiplier = 2f;
    public Transform wumpusPoint;
    public Player player;
    private Vector3 originalPosition;
    private AudioSource audioSource;
    private bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
        player.onReset += Reset;
        audioSource = GetComponent<AudioSource>();
        speed = Vector3.back * 0.032f * speedMultiplier;
    }

    private void Reset()
    {
        transform.position = originalPosition;
        audioSource.Stop();
        animator.enabled = true;
    }

    public void StartMoving()
    {
        isWalking = true;
        audioSource.Play();
    }

    void Update()
    {
        if (isWalking && transform.position.z > wumpusPoint.position.z + 4)
        {
            transform.position += speed;
        }
        else if (isWalking)
        {
            animator.enabled = false;
            player.Die();
            isWalking = false;
        }
    }
}
