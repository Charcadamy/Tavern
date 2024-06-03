using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (PauseMenuObject.activeInHierarchy == false)
            {
                PauseMenuObject.SetActive(true);
            }
            else
            {
                PauseMenuObject.SetActive(false);
            }
        }
        if (PauseMenuObject.activeInHierarchy)
        {
            PauseGame();
        }    
        else
        {
            ResumeGame();
        }
    }
    public void PauseButton()
    {

    }
    public void BacktoMenu()
    {

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
