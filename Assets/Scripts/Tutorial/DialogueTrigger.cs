using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogues dialogues;

    private void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        GetComponent<TutorialManager>().StartDialogue(dialogues);
    }
}
