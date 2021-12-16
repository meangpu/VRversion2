using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiCamScpt : MonoBehaviour
{
    Camera[] myCams = new Camera[1];

    void Start()
    {
        // Display.displays[1].Activate();
        // int width, height, refreshRate;
        // width = Screen.width;
        // height = Screen.height;
        // refreshRate = 144;
        // Display.displays[1].Activate(width, height, refreshRate);

        //Get Main Camera
        myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myCams[1] = GameObject.Find("Camera2").GetComponent<Camera>();


        //Call function when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;

        //Map each Camera to a Display
        mapCameraToDisplay();
    }
    

    void mapCameraToDisplay()
    {
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }
    }

    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }


}
