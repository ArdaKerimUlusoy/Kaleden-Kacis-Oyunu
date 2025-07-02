using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject kap�1;  
    public GameObject kap�2;  
    public bool isHidden = false; 

    private Renderer playerRenderer; 
    private Collider playerCollider;  

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Kap��n�ndeMiyim(kap�1))
        {
            ToggleVisibility();
        }
        if (Input.GetKeyDown(KeyCode.E) && Kap��n�ndeMiyim(kap�2))
        {
            ToggleVisibility();
        }
    }

    bool Kap��n�ndeMiyim(GameObject kap�)
    {
        return Vector3.Distance(transform.position, kap�.transform.position) < 2f;
    }

    void ToggleVisibility()
    {
        isHidden = !isHidden; 

        if (playerRenderer != null)
        {
            playerRenderer.enabled = !isHidden;
        }

        if (playerCollider != null)
        {
            playerCollider.enabled = !isHidden;
        }
    }
}
