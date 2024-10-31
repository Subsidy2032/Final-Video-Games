using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Desired speed
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        SetInitialVelocity(); // Set the initial random velocity
    }

    void SetInitialVelocity()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction.normalized * speed;
    }

    void Update()
    {
        // Ensure the ball maintains a constant speed
        if (rb.velocity.magnitude != speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D collidingRB = collision.transform.GetComponent<Rigidbody2D>();
        if (collidingRB != null)
        {
            // Reflect the object's velocity upon collision
            Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = newVelocity.normalized * speed; // Maintain the speed after reflection
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
        if (colliderRB != null)
        {
            // Reflect the object's velocity upon trigger
            colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, -collider.transform.up);
            colliderRB.velocity = colliderRB.velocity.normalized * speed; // Maintain the speed
        }
    }
}
