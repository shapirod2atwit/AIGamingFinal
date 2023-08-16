using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This script is used for showing what pieces we used to create to maps procedurally
*/

public class DemoPrefab : MonoBehaviour
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

    //hard code in each blockto display
    private void makeMap(){
        
        for(int i=0;i<map.GetUpperBound(0)-4;i++){
            for(int j=0;j<map.GetUpperBound(1)-4;j++){
               
               if(i==0 && j==0){
                    square3(i,j);
               }

               if(i==4 && j==0){
                    vrect4(i,j);
               }

               if(i==8 && j==0){
                    hrect4(i,j);
               }    

               if(i==13 && j==0){
                    vrect5(i,j);
               }

               if(i==17 && j==0){
                    hrect5(i,j);
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

