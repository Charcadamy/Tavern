using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void StartButton() //Code after you click the Start Button
    { 
        Debug.Log("Button Click Successful! (Start)"); 
    }

    public void SettingsButton() //Code after you click the Settings Button
    { 
        Debug.Log("Button Click Successful! (Settings)"); 
        
    }

    public void ExitButton() //Code after you click the Exit Button
    {
        Debug.Log("Button Click Successful! (Exit)");
        Application.Quit(); //Instantly Closes the Game
    }
}
