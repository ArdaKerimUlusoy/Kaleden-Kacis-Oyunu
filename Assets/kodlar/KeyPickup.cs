using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject kap�1;
    public GameObject kap�2;
    public GameObject blackoutPanel; 
    private bool isNearKey = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearKey = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearKey = false;
        }
    }

    void Update()
    {
        if (isNearKey && Input.GetKeyDown(KeyCode.E))
        {
            kap�1.SetActive(false);  
            kap�2.SetActive(true);   
            gameObject.SetActive(false); 
            blackoutPanel.SetActive(true);  
        }
    }
}
