using Player;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public NPC_Data npcData;
    
    public GameObject visualCue;

    private void Awake()
    {
        npcData.playerInRange = false; 
        visualCue.SetActive(false);
    }
    
    void Update()
    {
        //returns distance between two vectors 
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerStats.instance.PlayerPosition);
        
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
            
            if (CustomPlayerInputManager.instance.fPressed)
            {
                //Enter dialogue mode               //using text asset from each NPC Data
                DialogueManager.instance.EnterDialogueMode(npcData.inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

    }
}
