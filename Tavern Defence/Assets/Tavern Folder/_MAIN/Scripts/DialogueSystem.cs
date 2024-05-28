using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] List<string> lines;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
            //Pulling from the method called PushText()
        }
    }

    private void PushText()
    {
        if(lines.Count == 0)
        {
            Debug.Log("No more lines available.");
            return;
        }

        text.text = lines[0];
        lines.RemoveAt(0);
    }
}
