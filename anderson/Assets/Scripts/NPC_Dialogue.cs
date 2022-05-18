using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Dialogue : MonoBehaviour
{
  
    public NPC_Data npcData;
    public Transform player;
    public GameObject visualCue;

   
    
    private void Awake()
    {
       
        
        npcData.playerInRange = false; 
        visualCue.SetActive(false);
    }
    
    void Update()
    {
        //returns distance between two vectors 
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer <=  npcData.maxRange)
        {
            npcData.playerInRange = true;
        }

        if (distanceToPlayer >  npcData.maxRange)
        {
            npcData.playerInRange = false;
        }

        if (npcData.playerInRange && !DialogueManager.instance.dialogueIsPlaying)
        {
            //turn on visual cue to let player now that this object can be interacted with 
            visualCue.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Enter dialogue mode               //using text asset from each NPC Data
                DialogueManager.instance.EnterDialogueMode(npcData.inkJSON);
                
                //check if var match unique index from NPC Data
                //could probably use switch switch statement 
            
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

    }
}
