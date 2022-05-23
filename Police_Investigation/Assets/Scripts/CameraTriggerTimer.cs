using System.Collections;
using UnityEngine;

public class CameraTriggerTimer : MonoBehaviour
{
    [Tooltip("Put Camera you want to activate here")]
    public GameObject focusObjectCamera;
    [Tooltip("Put Camera you want to deactivate here")]
    public GameObject currentCamera;

    public bool hasBeenTriggered;
    public float timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !hasBeenTriggered)
        {
            StartCoroutine(CameraSwap());
            hasBeenTriggered = true;
        }
    }

    IEnumerator CameraSwap()
    {
        GameManager.instance.cannotMove = true;
        focusObjectCamera.SetActive(true);
        currentCamera.SetActive(false);
        yield return new WaitForSeconds(timer);
        GameManager.instance.cannotMove = false;
        currentCamera.SetActive(true);
    }

}
