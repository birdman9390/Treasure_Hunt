using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour {

    //Mask for collision detecting
    private bool foodDetected;
    private bool treasureDetected;
    private bool batteryDetected;


    //Collision Object with the player
    private GameObject gameObject;
    

    //Initialize
    void Start () {
        foodDetected = false;
        treasureDetected = false;
        batteryDetected = false;

    }

	// Update is called once per frame
	void Update () {
        if(foodDetected && Input.GetKey(KeyCode.G))
        {
            pickUp(gameObject);
        }
        else if (treasureDetected && Input.GetKey(KeyCode.G))
        {
            pickUp(gameObject);
        }
        else if (batteryDetected && Input.GetKey(KeyCode.G))
        {
            pickUp(gameObject);
        }

    }
    void OnCollisionEnter(Collision col)
    {
        switch(col.gameObject.tag)
        {
            case "Food":
                foodDetected = true;
                gameObject = col.gameObject;
                break;
            case "Treasure":
                treasureDetected = true;
                gameObject = col.gameObject;
                break;
            case "Battery":
                batteryDetected = true;
                gameObject = col.gameObject;
                break;
        }
    }
    void OnCollisionExit(Collision col)
    {
        switch(col.gameObject.tag)
        {
            case "Food":
                foodDetected = false;
                break;
            case "Treasure":
                treasureDetected = false;
                break;
            case "Battery":
                batteryDetected = false;
                break;
        }
    }
    void pickUp(GameObject gameObject)
    {
        switch (gameObject.tag)
        {
            case "Food":
                GameManager.remainHP = Math.Min(GameManager.remainHP + GameManager.RecoverByFood, GameManager.MAX_HP);
                foodDetected = false;
                GameManager.remainFood--;
                break;
            case "Treasure":
                GameManager.numTreasure++;
                treasureDetected = false;
                GameManager.remainTreasure--;
                break;
            case "Battery":
                GameManager.numBattery++;
                batteryDetected = false;
                GameManager.remainBattery--;
                break;
        }
        Destroy(gameObject);
    }

    
}
