using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    private Vector3 originalPosition; 
    private bool isFalling = false;

    public float fallDelay = 0.5f; 
    public float respawnTime = 3f; 

    private Collider2D col;
    private SpriteRenderer sr;

    void Start()
    {
        originalPosition = transform.position;
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(FallAndRespawn());
        }
    }

    IEnumerator FallAndRespawn()
    {
        isFalling = true;

        yield return new WaitForSeconds(fallDelay); 

        col.enabled = false; 
        sr.enabled = false; 

        yield return new WaitForSeconds(respawnTime); 

        transform.position = originalPosition; 
        col.enabled = true; 
        sr.enabled = true; 

        isFalling = false;
    }
}
