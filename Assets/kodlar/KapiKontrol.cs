using UnityEngine;
using UnityEngine.SceneManagement;

public class KapiKontrol : MonoBehaviour
{
    public GameObject kapý1; 
    public GameObject kapý2; 
    private bool[] passwordsCorrect = new bool[3]; 

    void Start()
    {
        kapý2.SetActive(false); 
        for (int i = 0; i < passwordsCorrect.Length; i++)
        {
            passwordsCorrect[i] = false; 
        }
    }

    public void SetPasswordCorrect(int panoIndex)
    {
        if (panoIndex >= 0 && panoIndex < passwordsCorrect.Length)
        {
            passwordsCorrect[panoIndex] = true;
            CheckAllPasswordsCorrect();
        }
    }

    private void CheckAllPasswordsCorrect()
    {
        if (passwordsCorrect[0] && passwordsCorrect[1] && passwordsCorrect[2]) 
        {
            kapý1.SetActive(false); 
            kapý2.SetActive(true);  
        }
    }

    void Update()
    {
        if (kapý2.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("3.Level");  
        }
    }
}
