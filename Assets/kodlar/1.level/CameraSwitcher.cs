using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera normalCam; 
    public CinemachineVirtualCamera cinematicCam; 
    private bool isCinematicActive = false;
    private bool canSwitchCamera = true; 
    public float cooldownTime = 10f; 

    void Start()
    {
        
        normalCam.Priority = 10;
        cinematicCam.Priority = 5;
    }

    void Update()
    {
       
        if (canSwitchCamera && Input.GetKeyDown(KeyCode.Space))
        {
            isCinematicActive = true;
            normalCam.Priority = 5;  
            cinematicCam.Priority = 10; 

         
            Invoke("ResetCamera", 2f);

            canSwitchCamera = false;
            Invoke("ResetCameraCooldown", cooldownTime);
        }
    }

    void ResetCamera()
    {
        isCinematicActive = false;
        normalCam.Priority = 10;
        cinematicCam.Priority = 5;
    }

    void ResetCameraCooldown()
    {
        canSwitchCamera = true; 
    }
}
