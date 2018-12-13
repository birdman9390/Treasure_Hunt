using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    // Use this for initialization

    
    //Set up Max HP, FPS
    public static int MAX_HP = 150;
    public static int FPS = 60;

    //This variable refers to the HP drop per second( = per FPS frame)
    public const int HPdps = 2;

    //Indicates how much HP does the player recovers when he/she eats a food Item
    public static int RecoverByFood = 10;

    //Indicates how many times does the flashlight strengthen when the player use battery item
    public static int BatteryTime = 20;

    //Indicates the remaining food, battery, treasure in the map
    public static int remainFood;
    public static int remainBattery;
    public static int remainTreasure;


    //Indicates the number of treasure, battery in the player's inventory
    public static int numTreasure;
    public static int numBattery;

    //Indicates the remaining HP
    public static int remainHP;

    //Variable for counting the frame
    public static int fpsCount;
    public int fpsCountLimit;


    //Default is false but when the number of remaining treasure boxes in the map become 0, isClear is set to true
    public static bool isClear;
    public static bool isDead;

    //Starting condition
    //If you have another set of items in the map by map customizing system, you should change this static member
    //by GameManager.remainFood = ??
    //   GameManager.remainBattery = ??
    //   GameManager.remainTreasure = ??
    void Start () {
        remainFood = 1;
        remainBattery = 1;
        remainTreasure = 1;
        numTreasure = 0;
        numBattery = 0;
        isClear = false;
        isDead = false;
        remainHP = MAX_HP;
        fpsCount = 0;
        fpsCountLimit = FPS / HPdps;
    }
	

    // Update is called once per frame
    void Update () {
        //       Debug.Log("numFood : "+BoxCollider.numFood);
        //      Debug.Log("numTreasure : "+ BoxCollider.numTreasure);
        //     Debug.Log("numBattery : "+ BoxCollider.numBattery);
        fpsCount = (fpsCount + 1) % fpsCountLimit;
        Debug.Log("HP : " + remainHP);

        //Check the game end condition
        if(remainTreasure==0)
        {
            isClear = true;
        }
        if(remainHP==0)
        {
            isDead = true;
        }


        //Print the log for game end condition
        if(isClear)
        {
            Debug.Log("Game Clear!!!");
        }
        if(isDead)
        {
            Debug.Log("Player Died!!!");
        }


        //If the game is not finished, decrease the remaining HP
        if(!isClear && !isDead && fpsCount==0)
        {
            remainHP--;
        }
    }
}
