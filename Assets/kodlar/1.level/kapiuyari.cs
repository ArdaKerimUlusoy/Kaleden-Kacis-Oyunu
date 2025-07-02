using UnityEngine;
using UnityEngine.UI;

public class kapiuyari : MonoBehaviour
{
    public GameObject enterText; 
    public GameObject ampulImage; 

    private void Start()
    {
        enterText.SetActive(false);
        ampulImage.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            enterText.SetActive(true);
            ampulImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            enterText.SetActive(false);
            ampulImage.SetActive(false);
        }
    }
}
