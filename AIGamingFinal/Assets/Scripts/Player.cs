using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This script 
*
* 
*/

public class Player : MonoBehaviour
{
    private int x;
    private int z;
    private GameObject gameLoader;
    private bool[,] map;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //calculate x and z position in 2d array
        x = (int)this.transform.position.x/11;
        z = (int)Mathf.Abs((float)((int)this.transform.position.z/11));

        //get the 2d array representation of the map
        gameLoader = GameObject.Find("GameLoader");
        map = gameLoader.GetComponent<PrefabMap>().map;
    }

    // Update is called once per frame
    void Update()
    {
        //player needs to give input and where they want to go needs to be valid
        //position in 2d array is updated after they reach the destination
        if((Input.GetKeyDown(KeyCode.W) && map[x,z-1])){
            //planes are 11 units apart, so move by 11
            this.transform.position += new Vector3(0, 0, 11.0f);
            z-=1;
        }else if(Input.GetKeyDown(KeyCode.A) && map[x-1,z]){
            this.transform.position += new Vector3(-11.0f, 0, 0);
            x-=1;
        }else if(Input.GetKeyDown(KeyCode.S) && map[x,z+1]){
            this.transform.position += new Vector3(0, 0, -11.0f);
            z+=1;
        }else if(Input.GetKeyDown(KeyCode.D) && map[x+1,z]){
            this.transform.position += new Vector3(11.0f, 0, 0);
            x+=1;
        }
    }

    //If the player collides with a coin,
    //destroy it and increase score
    private void OnTriggerEnter(Collider c)
    {
        if(string.Equals(c.gameObject.name,"Coin(Clone)")){
            Destroy(c.gameObject);
            score++;
        }
        
    }
}