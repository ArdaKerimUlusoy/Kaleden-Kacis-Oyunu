using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public GameObject mainMenuPanel;  
    public GameObject button;         

   
    void Start()
    {
        mainMenuPanel.SetActive(false);  
        button.SetActive(false);        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            bool isActive = !mainMenuPanel.activeSelf;
            mainMenuPanel.SetActive(isActive);  
            button.SetActive(isActive);         
        }
    }
}
