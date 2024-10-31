using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Default speed
    public float boostedSpeed = 8f; // Speed when player collides with the ball
    private float currentSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        currentSpeed = speed; // Set initial speed
        SetInitialVelocity(); // Set the initial random velocity
    }

    void SetInitialVelocity()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction.normalized * currentSpeed;
    }

    void Update()
    {
        // Ensure the ball maintains the current speed
        if (rb.velocity.magnitude != currentSpeed)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase speed when colliding with player
            currentSpeed = boostedSpeed;
        }
        else
        {
            // Revert to original speed on other collisions
            currentSpeed = speed;
        }

        Rigidbody2D collidingRB = collision.transform.GetComponent<Rigidbody2D>();
        if (collidingRB != null)
        {
            // Reflect the ball's velocity upon collision to maintain direction and speed
            Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = newVelocity.normalized * currentSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
        if (colliderRB != null)
        {
            // Reflect the object's velocity upon trigger and maintain speed
            colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, -collider.transform.up);
            colliderRB.velocity = colliderRB.velocity.normalized * currentSpeed;
        }
    }
}