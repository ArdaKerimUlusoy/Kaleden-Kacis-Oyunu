using UnityEngine;
using UnityEngine.UI; 

public class bitisbilgi : MonoBehaviour
{
    public Text hoverText; 
    void OnTriggerEnter2D()
    {
        hoverText.gameObject.SetActive(true); 
    }

    private void OnTriggerExit2D()
    {
        hoverText.gameObject.SetActive(false);  
    }
}
