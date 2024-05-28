using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public string line;
}

[CreateAssetMenu]
public class DialogueContainer : ScriptableObject
{
    public List<DialogueLine> lines;
}
