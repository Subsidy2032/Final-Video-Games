using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] float speed = 10f;
    [SerializeField] public float jumpAmount = 10f;

    private bool isGrounded = true;
    private Vector2 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
            Debug.LogError("Rigidbody2D could not be found");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        direction = new Vector2(horizontalInput, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    private void Jump()
    {
        JumpAnimation();
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
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
        if (collision.contactCount > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = false;
        }
    }

    private void JumpAnimation()
    {
        animator.SetBool("IsJumping", true);
    }

    private void WalkAnimation()
    {

    }
}
