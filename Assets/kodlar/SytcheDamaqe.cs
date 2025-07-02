using UnityEngine;

public class ScytheDamage : MonoBehaviour
{
    public int damageAmount = 5; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>(); 

        if (health != null) 
        {
            health.TakeDamage(damageAmount); 
        }
    }
}
