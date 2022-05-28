using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksonStates : MonoBehaviour
{

    public void OpenTheDoor()
    {
        DialogueManager.instance.currentStory.ObserveVariable("openDoor", LoadDoor);
    }

    private void LoadDoor(string variableName, object newValue)
    {
        GameManager.instance.openDoor = true;
    }

}
