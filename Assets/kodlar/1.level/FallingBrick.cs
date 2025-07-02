using UnityEngine;

public class FallingBrick : MonoBehaviour
{
    private Rigidbody2D rb;
    public float gravityScale = 3f;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
          
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(5);  
            }
            Destroy(gameObject);  
        }
    }
}
