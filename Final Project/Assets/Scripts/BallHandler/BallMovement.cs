using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float controlFactor = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Apply a random force to the ball in a random direction
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float forceMagnitude = Random.Range(5f, 10f); // Adjust these values for desired speed
        rb.AddForce(randomDirection * forceMagnitude, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);

        // Add a small random perturbation to the velocity
        float randomOffset = Random.Range(-0.1f, 0.1f);
        newVelocity.x += randomOffset;
        newVelocity.y += randomOffset;

        rb.velocity = newVelocity.normalized * rb.velocity.magnitude; // Maintain original speed
    }

    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Mathf.Abs(rb.velocity.x) < 0.1f || Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            // If the velocity is too uniform, introduce a slight nudge
            Vector2 nudge = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            rb.velocity += nudge;
        }
    }
}
