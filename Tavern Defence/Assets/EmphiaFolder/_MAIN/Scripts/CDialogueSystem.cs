using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueSystemB : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] List<string> lines;

    [SerializeField]
    [Range(0f, 1f)]
    float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;

    string lineToShow;

    private void Start()
    {
        CycleLine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
        }
        TypeOutText();
    }

    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f)
        {
            return;
        }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0f, 1f);
        UpdateText();
    }

    void UpdateText()
    {
        int totalLetterToShow = (int)(lineToShow.Length * visibleTextPercent);
        text.text = lineToShow.Substring(0, totalLetterToShow);
    }
    private void PushText()
    {
        if (visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }

        CycleLine();
    }

    private void CycleLine()
    {
        if (lines.Count == 0)
        {
            Debug.Log("Lines no more.");
            return;
        }

        lineToShow = lines[0];
        lines.RemoveAt(0);

        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;

        text.text = "";
    }
}
