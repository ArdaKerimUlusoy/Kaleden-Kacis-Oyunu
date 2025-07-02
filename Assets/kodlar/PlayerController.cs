using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject kapý1;  
    public GameObject kapý2;  
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
        if (Input.GetKeyDown(KeyCode.E) && KapýÖnündeMiyim(kapý1))
        {
            ToggleVisibility();
        }
        if (Input.GetKeyDown(KeyCode.E) && KapýÖnündeMiyim(kapý2))
        {
            ToggleVisibility();
        }
    }

    bool KapýÖnündeMiyim(GameObject kapý)
    {
        return Vector3.Distance(transform.position, kapý.transform.position) < 2f;
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
