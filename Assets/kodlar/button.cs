using UnityEngine;
using UnityEngine.SceneManagement; 

public class button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("1.level");
        Time.timeScale = 1f;
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("settings");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("baslangýc");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
