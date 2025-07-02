using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 5; 
    public float damageInterval = 1f; 
    private float lastDamageTime; 

    private void OnCollisionStay2D(Collision2D collision)
    {
      
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (Time.time >= lastDamageTime + damageInterval)
            {
                health.TakeDamage(damage); 
                lastDamageTime = Time.time; 
            }
        }
    }
}
