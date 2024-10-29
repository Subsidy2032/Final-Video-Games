using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 newDirection = Vector2.Reflect(rb.velocity, normal);
        rb.velocity = newDirection.normalized * speed;

        Vector2 separationForce = normal * 0.1f;
        rb.AddForce(separationForce, ForceMode2D.Impulse);
    }

    /*
    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Mathf.Abs(rb.velocity.x) < 0.1f || Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            Vector2 nudge = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            rb.velocity += nudge;
        }
    }*/
}
