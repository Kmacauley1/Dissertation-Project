using Player;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public NPC_Data npcData;
    public JacksonStates jacksonStates;
    public GameObject visualCue;

    private int Jackson;

    private void Awake()
    {
        Jackson = 0;
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

                if (Jackson == npcData.Index)
                {
                    jacksonStates.OpenTheDoor();
                }
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

    }
}
