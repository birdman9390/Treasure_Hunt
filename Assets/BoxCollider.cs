using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour {
    private bool foodDetected;
    private bool treasureDetected;
    private bool batteryDetected;

    public static int numFood;
    public static int numTreasure;
    public static int numBattery;

    private GameObject gameObject;
    // Use this for initialization
    void Start () {
        foodDetected = false;
        treasureDetected = false;
        batteryDetected = false;

        numFood = 0;
        numTreasure = 0;
        numBattery = 0;
    }
	// Update is called once per frame
	void Update () {
        if(foodDetected && Input.GetKey(KeyCode.G))
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
                numFood++;
                break;
            case "Treasure":
                numTreasure++;
                break;
            case "Battery":
                numBattery++;
                break;
        }
        Destroy(gameObject);
    }

    
}
