using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyAndDoorSystem : MonoBehaviour
{
    public GameObject key;
    public GameObject kapý1;
    public GameObject kapý2;
    public float pickUpRange = 0.5f; 

    public GameObject messageUI;
    public GameObject pictureUI;

    private bool hasKey = false;
    private bool nearDoor = false;
    private bool nearKey = false;

    void Update()
    {
        
        float distanceToKey = Vector3.Distance(transform.position, key.transform.position);

        if (distanceToKey <= pickUpRange && key.activeSelf)
        {
            nearKey = true;
            messageUI.SetActive(true); 
            pictureUI.SetActive(true);
        }
        else
        {
            nearKey = false;
            messageUI.SetActive(false); 
            pictureUI.SetActive(false);
        }

        if (nearKey && Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;
            key.SetActive(false);
            kapý1.SetActive(false);
            kapý2.SetActive(true);
            messageUI.SetActive(false); 
            
        }

        if (hasKey && nearDoor && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("2.level"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == kapý2)
        {
            nearDoor = true;
            Debug.Log("Kapýnýn önündesin, Enter'a basarak ilerleyebilirsin.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == kapý2)
        {
            nearDoor = false;
        }
    }
}
