using UnityEngine;
using UnityEngine.SceneManagement; 

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject gameOverPanel; 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameOverPanel.SetActive(false); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Character is dead!");
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void RestoreHealthOnNewLevel()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Health restored to max on new level!");
    }

    
}
