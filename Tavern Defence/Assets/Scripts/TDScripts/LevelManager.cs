using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;


    //Array to keep a list of all of the paths and their positions
    public Transform[] path;
    public Transform startPoint;
    
    
    void Awake(){
        main = this;
    }
    
    
    void Start()
    {
      
    }


    void Update()
    {
        
    }
}
