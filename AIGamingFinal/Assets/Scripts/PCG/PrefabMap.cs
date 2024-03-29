using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This script procedurally generates the map and renders it.
* It combines squares and rectangles while
* trying to create minimum overlap.
*/

public class PrefabMap : MonoBehaviour
{

    public GameObject tile;
    public int x = 24;
    public int y = 10;

    public bool[,] map;

    void Awake()
    {
        map = new bool[x,y];
        renderMap();
    }

    //renders a 2d array into the game using tile prefabs
    private void renderMap(){

        makeMap();

        for(int i = 0; i < map.GetUpperBound(0);i++){
            for(int j = 0; j < map.GetUpperBound(1);j++){
                //check if tile should be rendered
                if(map[i,j]){
                    //calculate position of tile
                    var position = new Vector3((i*11), 0, 0-(j*11));
                    //render tile
                    Instantiate(tile, position, Quaternion.identity);
                }
            }
        }
    }

    //creates a 2d array representation of the map
    private void makeMap(){
        
        for(int i=1;i<map.GetUpperBound(0)-4;i++){
            for(int j=1;j<map.GetUpperBound(1)-4;j++){
                
                //random number to determine prefab used
                float r = Random.Range(0.0f,1.0f);
                //random offset to prevent the top of the map being a straight line
                int offset = Mathf.FloorToInt(Random.Range(0.0f,2.0f));
                //get how many neighbors the current index has
                int numNeighbors = checkAdjNeighbors(i,j);

                //check if the index is occupied and
                //and if it has less than 2 neighbors
                //if both conditions are met, assign a random prefab
                if(!map[i,j] && numNeighbors < 2){
                    if(r >= 0.0f && r < 0.2f){
                        square3(i,j-offset);
                    }else if(r >= 0.2f && r < 0.4f){
                        vrect4(i,j-offset);
                    }else if(r >= 0.4f && r < 0.6f){
                        hrect4(i,j-offset);
                    }else if(r >= 0.6f && r < 0.8f){
                        vrect5(i,j-offset);
                    }else if(r >= 0.8f && r < 1.0f){
                        hrect5(i,j-offset);
                    }
                    
                }
            }
        }
    }

    //gets the number of adjacent neighbors
    private int checkAdjNeighbors(int x, int y){

        int counter = 0;

        if(map[x-1,y]){
            counter++;
        }
        if(map[x,y-1]){
            counter++;
        }
        if(map[x+1,y]){
            counter++;
        }
        if(map[x,y+1]){
            counter++;
        }

        return counter;
    }

    //helper functions to create specific shapes
    private void square3(int x, int y){
        map[x,y]=true;
        map[x,y+1]=true;
        map[x,y+2]=true;
        map[x+1,y]=true;
        map[x+2,y]=true;
        map[x+1,y+2]=true;
        map[x+2,y+1]=true;
        map[x+2,y+2]=true;

    }

    private void vrect4(int x, int y){
        map[x,y]=true;
        map[x,y+1]=true;
        map[x,y+2]=true;
        map[x,y+3]=true;
        map[x+1,y]=true;
        map[x+2,y]=true;
        map[x+2,y+1]=true;
        map[x+2,y+2]=true;
        map[x+2,y+3]=true;
        map[x+1,y+3]=true;
    }

    private void hrect4(int x, int y){
        map[x,y]=true;
        map[x+1,y]=true;
        map[x+2,y]=true;
        map[x+3,y]=true;
        map[x,y+1]=true;
        map[x,y+2]=true;
        map[x+1,y+2]=true;
        map[x+2,y+2]=true;
        map[x+3,y+2]=true;
        map[x+3,y+1]=true;
    }

    private void vrect5(int x, int y){
        map[x,y]=true;
        map[x,y+1]=true;
        map[x,y+2]=true;
        map[x,y+3]=true;
        map[x,y+4]=true;
        map[x+1,y]=true;
        map[x+2,y]=true;
        map[x+2,y+1]=true;
        map[x+2,y+2]=true;
        map[x+2,y+3]=true;
        map[x+2,y+4]=true;
        map[x+1,y+4]=true;
    }

    private void hrect5(int x, int y){
        map[x,y]=true;
        map[x+1,y]=true;
        map[x+2,y]=true;
        map[x+3,y]=true;
        map[x+4,y]=true;
        map[x,y+1]=true;
        map[x,y+2]=true;
        map[x+1,y+2]=true;
        map[x+2,y+2]=true;
        map[x+3,y+2]=true;
        map[x+4,y+2]=true;
        map[x+4,y+1]=true;
    }
}

