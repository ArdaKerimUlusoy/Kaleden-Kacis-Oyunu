using UnityEngine;
using UnityEngine.UI;

public class DarknessEffect : MonoBehaviour
{
    public Image darkPanel; 
    private float originalAlpha = 0.7f; 
    private float lightAlpha = 0.3f; 
    private bool canToggleDarkness = true; 
    public float cooldownTime = 10f; 

    void Start()
    {
        if (darkPanel != null)
        {
            Color panelColor = darkPanel.color;
            panelColor.a = originalAlpha; 
            darkPanel.color = panelColor;
        }
    }

    void Update()
    {
        if (canToggleDarkness && Input.GetKeyDown(KeyCode.Space))
        {
            
            if (darkPanel != null)
            {
                Color panelColor = darkPanel.color;
                panelColor.a = lightAlpha; 
                darkPanel.color = panelColor;
            }
            Invoke("ResetDarkness", 2f);

            canToggleDarkness = false;
            Invoke("ResetCooldown", cooldownTime); 
        }
    }

    void ResetDarkness()
    {
        if (darkPanel != null)
        {
            Color panelColor = darkPanel.color;
            panelColor.a = originalAlpha; 
            darkPanel.color = panelColor;
        }
    }

    void ResetCooldown()
    {
        canToggleDarkness = true; 
    }
}
