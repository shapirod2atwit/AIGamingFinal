using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* This script is resposible for displaying the player score,
* and loading reloading the scene if the player collects all
* of the coins
*/

public class UI : MonoBehaviour
{
    public Text textString;
    public Canvas canvas;
    private GameObject scoreHolder;
    private GameObject player;
    private int playerScore;
    int numCoins;

    void Awake()
    {
        scoreHolder = null;
    }

    void Start(){
       player = GameObject.Find("Player(Clone)");
       numCoins = GameObject.FindGameObjectsWithTag("Spawn").Length-1;
       scoreHolder = null;
     
    }

    // Update is called once per frame
    void Update()
    {
        //get the score holder object once it is loaded
        if(scoreHolder == null){
            scoreHolder = GameObject.Find("ScoreHolder");
        }
        
        //get the player's current score
        playerScore = scoreHolder.GetComponent<ScoreHolder>().score;

        //output player score to UI
        textString.text = "Score: "+ playerScore;

        //reload scene if all coins are collected
        if(player.GetComponent<Player>().score == numCoins){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
