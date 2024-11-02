using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        Collider2D collider = GetComponent<Collider2D>();
        PhysicsMaterial2D bouncyMaterial = new PhysicsMaterial2D
        {
            bounciness = 1f,
            friction = 0f
        };
        collider.sharedMaterial = bouncyMaterial;
    }
}