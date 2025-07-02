using UnityEngine;

public class MovingPlatformUst : MonoBehaviour
{
    public Transform pointC;  
    public Transform pointD; 
    public float speed = 2f; 

    private Vector3 target;  

    void Start()
    {
        target = pointD.position; 
    }

    void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointC.position) ? pointD.position : pointC.position;
        }
    }
}
