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
    }
    public void PauseButton()
    {

    }
    public void BacktoMenu()
    {

    }
}
