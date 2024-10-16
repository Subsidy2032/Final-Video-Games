using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] public float jumpAmount = 10f;

    private bool isGrounded = true;  // Starts as true to allow initial jump
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Rigidbody2D could not be found");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction = new Vector2(horizontalInput, 0);

        // Allow jump when space is pressed and player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        isGrounded = false;  // Once the player jumps, they're no longer grounded
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When colliding with any surface, set isGrounded to true
        if (collision.contacts[0].normal.y > 0.5f)  // Checks if the collision is from below
        {
            isGrounded = true;
        }

        // Handle ball collision to trigger jump
        if (collision.gameObject.CompareTag(ObjectTagsEnum.Ball.ToString()))
        {
            Jump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if there are any contacts before accessing them
        if (collision.contactCount > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = false;
        }
    }
}
