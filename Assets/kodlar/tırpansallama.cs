using UnityEngine;

public class tırpansallama : MonoBehaviour
{
    public float speed = 2f; 
    public float maxAngle = 45f;  

    void Update()
    {
        float angle = maxAngle * Mathf.Sin(Time.time * speed);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
