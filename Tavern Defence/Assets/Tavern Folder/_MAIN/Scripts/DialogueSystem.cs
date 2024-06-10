using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI nameTag;
    DialogueContainer currentDialogue;

    [SerializeField]
    [Range(0f,1f)]
    float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    //Speed of text displaying on screen.

    String lineToShow;

    int index;

    [SerializeField] DialogueContainer debugDialogueContainer;


    private void Start()
    {
        if (debugDialogueContainer != null)
        {
            InitiateDialogue(debugDialogueContainer);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
            //Pulling from the method called PushText().
        }

        TypeOutText();
    }

    public void InitiateDialogue(DialogueContainer dialogueContainer)
    {
        currentDialogue = dialogueContainer;
        index = 0;
        CycleLine();
    }

    private void TypeOutText()
    {
        if(visibleTextPercent >= 1f)
        {
            return;
        }

        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0f, 1f);
        //Makes the lines like typewriter.
        UpdateText();
    }

    void UpdateText()
    {
        int totalLetterToShow = (int)(lineToShow.Length * visibleTextPercent);
        text.text = lineToShow.Substring(0, totalLetterToShow);
        //Updates the text
    }

    private void PushText()
    {
        if(visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }

        CycleLine();
    }

    private void CycleLine()
    {
        if (index >= currentDialogue.lines.Count)
        {
            Debug.Log("No more lines available.");
            return;
        }
        //Just tells when there are no more strings/lines to display.

        lineToShow = currentDialogue.lines[index].line;
        //Removes lines one by one to display.

        if (currentDialogue.lines[index].actor != null)

        {
            nameTag.text = currentDialogue.lines[index].actor.Name;
        }
        // To check if there is a character (actor) attached to it || If so get the name and shove it in the text - elijah

        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        //Text typeout.

        text.text = "";

        index += 1;
    }
}
