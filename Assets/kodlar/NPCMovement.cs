using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform player;  
    public Transform[] patrolPoints; 
    public float speed = 3f; 
    public float takipMenzili = 10f; 
    public float hasarMenzili = 1f; 
    private int currentPoint = 0;

    private PlayerController playerController;
    private Health playerHealth;
    private float damageCooldown = 1f; 
    private float lastDamageTime;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        if (playerController != null)
        {
            float mesafe = Vector3.Distance(transform.position, player.position);

            if (!playerController.isHidden && mesafe < takipMenzili)
            {
                TakipEt();
            }
            else
            {
                Devriye();
            }

            if (mesafe < hasarMenzili)
            {
                DealDamage();
            }
        }
        else
        {
            Debug.LogError("PlayerController referansý bulunamadý!");
        }
    }

    void TakipEt()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        transform.position += direction * speed * Time.deltaTime;
        FlipCharacter(direction.x);
    }

    void Devriye()
    {
        if (patrolPoints.Length == 0) return;

        Vector3 target = patrolPoints[currentPoint].position;
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0;

        transform.position += direction * speed * Time.deltaTime;
        FlipCharacter(direction.x);

        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void FlipCharacter(float moveDirection)
    {
        Vector3 scale = transform.localScale;
        if (moveDirection > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (moveDirection < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    void DealDamage()
    {
        if (playerHealth != null && Time.time - lastDamageTime >= damageCooldown)
        {
            playerHealth.TakeDamage(10);
            lastDamageTime = Time.time;
        }
    }
}