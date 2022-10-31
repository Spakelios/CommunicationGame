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
    private AudioManager audioManager;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        Debug.Log("Starting conversation");
        nameText.text = dialogue.name;
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
        Debug.Log("End");
        dialogueBox.SetActive(false);
    }
}