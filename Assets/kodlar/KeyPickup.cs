using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject kapý1;
    public GameObject kapý2;
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
            kapý1.SetActive(false);  
            kapý2.SetActive(true);   
            gameObject.SetActive(false); 
            blackoutPanel.SetActive(true);  
        }
    }
}
