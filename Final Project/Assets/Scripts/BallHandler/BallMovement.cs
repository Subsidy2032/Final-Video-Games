//using UnityEngine;

//public class BallMovement : MonoBehaviour
//{
//    public float speed = 5f;
//    public float boostedSpeed = 8f;
//    private float currentSpeed;
//    private Rigidbody2D rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

//        currentSpeed = speed;
//        SetInitialVelocity();
//    }

//    void SetInitialVelocity()
//    {
//        float angle = Random.Range(0f, 360f);
//        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
//        rb.velocity = direction.normalized * currentSpeed;
//    }

//    void Update()
//    {
//        if (rb.velocity.magnitude != currentSpeed)
//        {
//            rb.velocity = rb.velocity.normalized * currentSpeed;
//        }
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            currentSpeed = boostedSpeed;
//        }
//        else
//        {
//            currentSpeed = speed;
//        }

//        Rigidbody2D collidingRB = collision.transform.GetComponent<Rigidbody2D>();
//        if (collidingRB != null)
//        {
//            Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
//            rb.velocity = newVelocity.normalized * currentSpeed;
//        }
//    }

//    void OnTriggerEnter2D(Collider2D collider)
//    {
//        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
//        if (colliderRB != null)
//        {
//            colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, -collider.transform.up);
//            colliderRB.velocity = colliderRB.velocity.normalized * currentSpeed;
//        }
//    }
//}



























using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float bounceForce = 10f; // Initial force applied to each ball
    public float bounciness = 1f;   // Bounciness level, where 1 is fully elastic

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Apply an initial random force to each ball to start the movement
        Vector2 initialForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * bounceForce;
        rb.AddForce(initialForce, ForceMode2D.Impulse);

        // Set up bouncy physics material
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            PhysicsMaterial2D bounceMaterial = new PhysicsMaterial2D();
            bounceMaterial.bounciness = bounciness;
            bounceMaterial.friction = 0f; // Ensures no friction, keeping speed consistent
            collider.sharedMaterial = bounceMaterial;
        }
    }
}