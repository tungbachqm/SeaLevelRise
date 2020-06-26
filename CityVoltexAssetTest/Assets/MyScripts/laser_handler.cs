/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using System.Linq;

public class laser_handler : MonoBehaviour
{
    public static int state;
    public static graphPicHandler graphPic;
    public static int slr_data_key;
    public SteamVR_LaserPointer laserPointer;
    public static FisrtMapHandler first_map_handler; 

    void Awake()
    {
        //laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        state = 0;

        first_map_handler = new FisrtMapHandler();
        
        graphPic = new graphPicHandler();
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        //Debug.Log(e.target.name);
        Debug.Log(e.target.name);
        switch (state)
        {   
            case 0:
                if (first_map_handler.getMapColsName().Contains(e.target.name)){
                    firstMapDeactivate(e.target.name);
                    state = 1;
                    graphPic.activate();
                }
                break;
            case 1:
                if (graphPic.getGraphColNameList().Contains(e.target.name))
                {
                    Debug.Log(e.target.name);
                    graphPic.deactivate();
                    state = 2;
                }
                break;
            default:
                Debug.Log(e.target.name);
                if (e.target.name == "Map0Col")
                {
                    Debug.Log("Cube was clicked");
                }
                else if (e.target.name == "Button")
                {
                    Debug.Log("Button was clicked");
                }
                else
                {
                    Debug.Log("Is clicked");
                }
                Debug.Log(e.target.name);
                break;
        }
        
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }
    public void firstMapDeactivate(string mapColName)
    {
        first_map_handler.deactivate();
        InputController.setSLRdatabase(mapColName);
    }
}