using UnityEngine;
using UnityEngine.UI;
using System.Collections; 

public class spoiler : MonoBehaviour
{
    public GameObject infoImage;
    public float interactionRange = 0.5f;  
    private bool isImageActive = false;   

    private Transform player;
    private Coroutine imageCoroutine; 

    void Start()
    {
        infoImage.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, player.position) <= interactionRange)
        {
            isImageActive = !isImageActive;
            infoImage.SetActive(isImageActive);
            if (isImageActive && imageCoroutine != null)
            {
                StopCoroutine(imageCoroutine); 
            }
            if (isImageActive)
            {
                imageCoroutine = StartCoroutine(CloseImageAfterDelay(5f)); 
            }
        }
        if (Vector3.Distance(transform.position, player.position) > interactionRange)
        {
            if (isImageActive)
            {
                isImageActive = false;
                infoImage.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isImageActive = false;
            infoImage.SetActive(false);
        }
    }

    private IEnumerator CloseImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        infoImage.SetActive(false); 
        isImageActive = false;
    }
}
