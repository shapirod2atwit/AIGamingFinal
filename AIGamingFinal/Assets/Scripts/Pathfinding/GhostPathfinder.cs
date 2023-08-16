using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPathfinder : MonoBehaviour
{
    // Start is called before the first frame update
    private int x, z, playerX, playerZ;
    private GameObject gameLoader;
    private bool[,] map;
    private GameObject player;

    private int counter = -50;
    void Start()
    {
        x = (int)this.transform.position.x/11;
        z = (int)Mathf.Abs((float)((int)this.transform.position.z/11));

        gameLoader = GameObject.Find("GameLoader");
        map = gameLoader.GetComponent<PrefabMap>().map;
        player = GameObject.Find("Player(Clone)");

        playerX = player.GetComponent<Player>().x;
        playerZ = player.GetComponent<Player>().z;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.GetComponent<Player>().x;
        playerZ = player.GetComponent<Player>().z;

        if(counter >= 200){
            if(z>playerZ && map[x,z-1]){
                this.transform.position += new Vector3(0, 0, 11.0f);
                z-=1;
            }else if(x>playerX && map[x-1,z]){
                this.transform.position += new Vector3(-11.0f, 0, 0);
                x-=1;
            }else if(z<playerZ && map[x,z+1]){
                this.transform.position += new Vector3(0, 0, -11.0f);
                z+=1;
            }else if(x<playerX && map[x+1,z]){
                this.transform.position += new Vector3(11.0f, 0, 0);
                x+=1;
            }
            counter=0;
        }
        
        counter++;
    }
}
