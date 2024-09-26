using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] public float jumpAmount = 10f;
    private bool isGrounded;
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
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTagsEnum.Ground.ToString()))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ObjectTagsEnum.Ball.ToString()))
        {
            Jump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ObjectTagsEnum.Ground.ToString()))
        {
            isGrounded = false;
        }
    }
}
