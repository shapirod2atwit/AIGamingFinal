using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text textString;
    public Canvas canvas;
    private GameObject player = null;
    private int score;

    // Start is called before the first frame update
    // void Start()
    // {
    //     // player = GameObject.Find("Player(Clone)");
    //     // score = player.GetComponent<Player>().score;
    //     textString.text = "Score: ";
    // }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            player = GameObject.Find("Player(Clone)");
            score = player.GetComponent<Player>().score;
            textString.text = "Score: "+ score;
        }
        score = player.GetComponent<Player>().score;
        textString.text = "Score: "+ score;
    }
}
