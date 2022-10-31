using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReadNote : MonoBehaviour
{
    public Dialogue dialogue;
    public bool inRange;
    private DialogueManager dialogueManager;
    public NotesPlayer player;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        player = FindObjectOfType<NotesPlayer>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            player.readNote = this;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        inRange = false;
        player.readNote = null;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    
}

