using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* This script randomly determines where all of the objects the player
* can interact with, including the player.
*/
public class LoadObjects : MonoBehaviour
{

    public GameObject player;
    public GameObject coin;
    public GameObject ghost;


    // Start is called before the first frame update
    void Start()
    {
        //get all possible spawn locations, and get a random one's position
        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("Spawn");
        int location = Mathf.FloorToInt(Random.Range(0.0f,(float) (spawnLocations.Length-2)));
        Vector3 spawnPosition = new Vector3(spawnLocations[location].transform.position.x, 1, spawnLocations[location].transform.position.z);

        //create the player at the random location
        Instantiate(player, spawnPosition, Quaternion.identity);

        //create coins on every position but the player's
        for(int i=0; i<spawnLocations.Length;i++){
            if(i!=location){
                Vector3 coinPosition = new Vector3(spawnLocations[i].transform.position.x, 1, spawnLocations[i].transform.position.z);

                //create coin
                Instantiate(coin, coinPosition, Quaternion.identity);
            }
        }

        //CHANGE LATER
        for(int i=0; i<4;i++){
            int l = Mathf.FloorToInt(Random.Range(0.0f,(float) (spawnLocations.Length-2)));
            while(location == l){
                l = Mathf.FloorToInt(Random.Range(0.0f,(float) (spawnLocations.Length-2)));
            }
            Vector3 coinPosition = new Vector3(spawnLocations[l].transform.position.x, 1, spawnLocations[l].transform.position.z);

            //create the player at the random location
            Instantiate(ghost, coinPosition, Quaternion.identity);

        }
    }

}
