using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour

    
{
    [Tooltip("Put Camera you want to activate here")]
    public GameObject cameraOn;
    [Tooltip("Put Camera you want to deactivate here")]
    public GameObject cameraOff;
    
   
    void OnTriggerEnter(Collider other)
    {
        //check for object tag
        if (other.tag == "Player")
        {
            // turns off whatever camera is in off and turns on the cam in on
            Debug.Log("Collided");
            cameraOn.SetActive(true);
            cameraOff.SetActive(false);
            
        }
    }

   
   
}
