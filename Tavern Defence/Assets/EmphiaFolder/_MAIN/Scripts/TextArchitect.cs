using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextArchitect 
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;
    // Creating a couple of variables, one for ui and one for world?
    public TMP_Text Tmpro => tmpro_ui;
    // TBH I don't know what this does. I assume it makes the variable tmpro and makes it equal to tmpro_ui and if it's null thenit becomes tmpro_world.
    // I did learn that ? is just a shortened "if" statement. : is a shortened "else" statement;

    public string currentText => Tmpro.text;
    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = "";
    // IG get; private set; means you can get the variable outside the class?
    private int preTextLength = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod {  instant, typewriter, fade }
    public BuildMethod buildMethod = BuildMethod.typewriter;
    // This is how the text forms in front of the player. Like word by word IG.

    public Color textColor { get { return Tmpro.color; } set { Tmpro.color = value; } }
    // COLOURS. IT'S COLOURS WITH A U. PLEASE. I'M BUT A MERE CANADIAN. STOP SUBJECTING ME TO YOUR AMERICAN WAYS, UNITY. 

    public float speed { get { return baseSpeed * speedMultiplier; } set { speedMultiplier = value; } }
    private const float baseSpeed = 1;
    private float speedMultiplier = 1;
    // How fast the words are going.

    public int charactersPerCycle { get { return speed <= 2f ? characterMultiplier : speed <= 2.5f ? characterMultiplier * 2 : characterMultiplier * 3; } }
    private int characterMultiplier = 1;

    public bool hurryUp = false;

    public TextArchitect(TextMeshProUGUI tmpro_ui)
    {
        this.tmpro_ui = tmpro_ui;
    }
    public TextArchitect(TextMeshPro tmpro_world)
    {
        this.tmpro_world = tmpro_world;
    }

    public Coroutine Build(string text)
    {
        preText = "";
        targetText = text;

        Stop();

        buildProcess = Tmpro.StartCoroutine(Building());
        return buildProcess;
    }
    // Append text to what is already in the text architect
    public Coroutine Append(string text)
    {
        preText = Tmpro.text;
        targetText = text;

        Stop();

        buildProcess = Tmpro.StartCoroutine(Building());
        return buildProcess;
    }

    private Coroutine buildProcess = null;
    //The buildProcess is what's going to be handling text generation
    public bool isBuilding => buildProcess != null;

    public void Stop()
    {
        if (!isBuilding)
            return;

        Tmpro.StopCoroutine(buildProcess);
        buildProcess = null;
    }

    IEnumerator Building()
    {
        yield return null;
    }

}
