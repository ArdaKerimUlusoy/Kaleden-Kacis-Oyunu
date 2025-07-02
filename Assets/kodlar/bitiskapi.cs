using UnityEngine;
using UnityEngine.SceneManagement;  

public class bitiskapi : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("baslangýc"); 
        }
    }
}
