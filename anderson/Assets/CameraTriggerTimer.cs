using System.Collections;
using UnityEngine;

public class CameraTriggerTimer : MonoBehaviour
{
    [Tooltip("Put Camera you want to activate here")]
    public GameObject focusObjectCamera;
    [Tooltip("Put Camera you want to deactivate here")]
    public GameObject currentCamera;

    public float timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CameraSwap());
        }
    }

    IEnumerator CameraSwap()
    {
        focusObjectCamera.SetActive(true);
        currentCamera.SetActive(false);
        yield return new WaitForSeconds(timer);
        currentCamera.SetActive(true);
    }

}
