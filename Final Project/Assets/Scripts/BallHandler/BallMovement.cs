using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float controlFactor = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle * speed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 controlVector = new Vector2(horizontalInput, verticalInput).normalized * controlFactor;

        rb.velocity += controlVector * speed * Time.deltaTime;

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTagsEnum.LeftWall.ToString()) ||
            collision.gameObject.CompareTag(ObjectTagsEnum.RightWall.ToString()) ||
            collision.gameObject.CompareTag(ObjectTagsEnum.Ground.ToString()) ||
            collision.gameObject.CompareTag(ObjectTagsEnum.Ceiling.ToString()))
        {
            Vector2 reflectDirection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflectDirection.normalized * speed;
        }
    }
}
