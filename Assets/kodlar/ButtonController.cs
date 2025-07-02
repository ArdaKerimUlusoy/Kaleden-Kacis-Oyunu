using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    public GameObject blackoutPanel; 
    private bool isNearButton = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearButton = false;
        }
    }

    void Update()
    {
        if (isNearButton && Input.GetKeyDown(KeyCode.E))
        {
            door.SetActive(false); 
            blackoutPanel.SetActive(false); 
        }
    }
}
