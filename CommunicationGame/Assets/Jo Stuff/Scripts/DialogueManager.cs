using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialogueBox;
    public NotesPlayer player;
    public bool readingNote;


    void Start()
    {
        readingNote = false;
        player = FindObjectOfType<NotesPlayer>();
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        player.canMove = false;
        readingNote = true;
        nameText.text = dialogue.name;
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextLine();
        
        
    }

    public void DisplayNextLine()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    

    public void EndDialogue()
    {
        readingNote = false;
        player.canMove = true;
        dialogueBox.SetActive(false);
    }
}