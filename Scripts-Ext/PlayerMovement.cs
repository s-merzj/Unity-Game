using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField]private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform flippedGroundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool spawnGravFlipped;

    private bool gravFlipped = false;

    void Start() {
        SetGravFlip(!spawnGravFlipped);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * ((gravFlipped) ? -1 : 1));
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        if (!gravFlipped) {
            return Physics2D.OverlapCircle(groundCheck.position, 0.35f, groundLayer);
        } else {
            return Physics2D.OverlapCircle(flippedGroundCheck.position, 0.35f, groundLayer);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void SetGravFlip(bool gravDown) {
        gravFlipped = !gravDown;
        rb.gravityScale = Mathf.Abs(rb.gravityScale) * ((gravFlipped) ? -1 : 1); // Flip gravity
        transform.Find("Anchor/Player sprite").GetComponent<SpriteRenderer>().flipY = gravFlipped; // Flip the sprite vertically
    }

    public bool gravityFlipped {get => gravFlipped; set => SetGravFlip(!value);}
}
