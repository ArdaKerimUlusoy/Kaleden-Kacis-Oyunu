using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 3f;   
    public float jumpForce = 1.5f;  
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    [Header("Ground Check Settings")]
    public Transform groundCheck; 
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(moveInput));

        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }


    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("jump", true);
        }

        if (isGrounded)
        {
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("SlowGround"))
        {
            moveSpeed = 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("SlowGround"))
        {
            moveSpeed = 3f;
        }
    }
}
