using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* This script is responsible for holding the player's score when the scene is reloaded
*/
public class ScoreHolder : MonoBehaviour
{

    public int score = 0;
    public static ScoreHolder instance;
    void Awake()
    {
        //do not destory to keep track of score
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this){
            Destroy(gameObject);
        }

        //if the introductory menu is loaded, destroy this object to reset the score
        if(string.Equals(SceneManager.GetActiveScene().name,"EntryScene")){
            Destroy(gameObject);
        }
        
    }
    
}
