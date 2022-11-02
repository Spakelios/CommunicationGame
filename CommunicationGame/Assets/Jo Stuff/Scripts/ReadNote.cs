using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReadNote : MonoBehaviour
{
    public Dialogue dialogue;
    //public bool inRange;
    private DialogueManager dialogueManager;
    //public NotesPlayer player;

    public Player1 player1;
    public Player2 player2;
    public bool P1inRange;
    public bool P2inRange;
    
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialogueBox;
    public AudioSource read;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        //player = FindObjectOfType<NotesPlayer>();
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();
        P1inRange = false;
        P2inRange = false;
        read = GameObject.Find("Note").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = true;
            player1.readNote = this;
            dialogueManager.dialogueText = dialogueText;
            dialogueManager.nameText = nameText;
            dialogueManager.dialogueBox = dialogueBox;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = true;
            player2.readNote = this;
            dialogueManager.dialogueText = dialogueText;
            dialogueManager.nameText = nameText;
            dialogueManager.dialogueBox = dialogueBox;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            P1inRange = false;
            player1.readNote = null;
        }
        
        else if (other.CompareTag("Player2"))
        {
            P2inRange = false;
            player2.readNote = null;
        }
    }

    public void TriggerDialogueP1()
    {
        read.Play();
        player1.canMove = false;
        dialogueManager.StartDialogue(dialogue);
    }
    
    public void TriggerDialogueP2()
    {
        read.Play();
        player2.canMove = false;
        dialogueManager.StartDialogue(dialogue);
    }
    
}

