using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float boostedSpeed = 8f;
    private float currentSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        currentSpeed = speed;
        SetInitialVelocity();
    }

    void SetInitialVelocity()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction.normalized * currentSpeed;
    }

    void Update()
    {
        if (rb.velocity.magnitude != currentSpeed)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentSpeed = boostedSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        Rigidbody2D collidingRB = collision.transform.GetComponent<Rigidbody2D>();
        if (collidingRB != null)
        {
            Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = newVelocity.normalized * currentSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
        if (colliderRB != null)
        {
            colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, -collider.transform.up);
            colliderRB.velocity = colliderRB.velocity.normalized * currentSpeed;
        }
    }
}