using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jacksondoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.openDoor == true)
        {
            gameObject.SetActive(false);
        }
    }
}
