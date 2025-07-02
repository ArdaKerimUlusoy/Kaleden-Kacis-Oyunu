using UnityEngine;
using UnityEngine.SceneManagement;

public class KapiKontrol : MonoBehaviour
{
    public GameObject kap�1; 
    public GameObject kap�2; 
    private bool[] passwordsCorrect = new bool[3]; 

    void Start()
    {
        kap�2.SetActive(false); 
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
            kap�1.SetActive(false); 
            kap�2.SetActive(true);  
        }
    }

    void Update()
    {
        if (kap�2.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("3.Level");  
        }
    }
}
