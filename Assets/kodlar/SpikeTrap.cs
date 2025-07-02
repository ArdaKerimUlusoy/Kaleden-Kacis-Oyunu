using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damage = 5; 
    public float damageInterval = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(ApplyDamage(other.GetComponent<Health>()));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ApplyDamage(Health playerHealth)
    {
        while (true)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
