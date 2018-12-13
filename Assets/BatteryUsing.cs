using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryUsing : MonoBehaviour {
    Light lightObject = null;

    int fpsCount;
    bool isOn;
	// Use this for initialization
	void Start () {
        lightObject = GetComponent<Light>();
        isOn = false;
        lightObject.spotAngle = 70;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F) && GameManager.numBattery>0)
        {
            GameManager.numBattery--;
            lightObject.spotAngle = 130;
            fpsCount = 0;
            isOn = true;
        }


        if(isOn)
        {
            fpsCount++;

            if(fpsCount>=GameManager.FPS * GameManager.BatteryTime)
            {
                lightObject.spotAngle = 70;
                isOn = false;
            }
        }
	}
}
