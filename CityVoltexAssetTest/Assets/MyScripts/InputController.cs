using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    public SteamVR_Action_Boolean pressAAAction;
    public SteamVR_Action_Vector2 touchPadAction;
    public SteamVR_Action_Boolean goBack;
    public GameObject water;
    
    public static string mapRCPName;
    public static SLR_data_handling slr_data;
    public static List<List<float>> slr_data_list;
    public static float water_mean_value;
    public static float water_min_value;
    public static float water_max_value;
    public static float temp_inc_water_value;


    private bool go_back;
    private int list_index;
    private Vector3 base_pos;

    public Text slr_text;
    void Start()
    {
        
        
      
        //Debug.Log("THis is value of datalist " + slr_data_list[1][0] + slr_data_list[1][1]);
        /*foreach (List<float> l in slr_data_list)
        {
            Debug.Log("THis is value of l " + l[1] );
        }*/
        list_index = 0;

        base_pos = water.transform.position;

    }


    // Update is called once per frame
    void Update()
    {
        
        go_back = goBack.GetLastStateDown(SteamVR_Input_Sources.LeftHand);
        switch (laser_handler.state)
        {
            case 0:
                break;
            case 1:
                if (go_back)
                {
                    laser_handler.state = 0;
                    laser_handler.first_map_handler.activate();
                    laser_handler.graphPic.deactivate();
                }
                else
                {
                    changeGraphPic();
                }
                break;
            case 2:
                if (go_back)
                {
                    laser_handler.state = 1;
                    slr_text.text = "";
                    list_index = 0;
                    water.transform.position = base_pos;
                    laser_handler.graphPic.activate();
                }
                else
                {
                    waterLevelchange();
                }
                break;
            default:
                break;
        }

        
    }

    private void waterLevelchange()
    {
        
       
        if (pressAAAction.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (list_index < slr_data_list.Count - 1)
            {
                list_index += 1;
                temp_inc_water_value = water_mean_value = slr_data_list[list_index][1];
                water_min_value = slr_data_list[list_index][2];
                water_max_value = slr_data_list[list_index][3];
            }

        }
        if (pressAAAction.GetLastStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (list_index > 0)
            {
                list_index -= 1;
                temp_inc_water_value = water_mean_value = slr_data_list[list_index][1];
                water_min_value = slr_data_list[list_index][2];
                water_max_value = slr_data_list[list_index][3];
            }

        }
        
        Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        //print(touchpadValue);
        if (touchpadValue[0] > 0)
        {
            if (temp_inc_water_value < water_max_value )
            {
                temp_inc_water_value += (float)0.01;
            }
            
        }
        if (touchpadValue[0] < 0)
        {
            if (temp_inc_water_value > water_min_value)
            {
                temp_inc_water_value -= (float)0.01;
            }
            
        }
        //Debug.Log(slr_data_list[list_index][1]*5);
        //Debug.Log(list_index);
        //Debug.Log(slr_data_list.Count);
        
        water.transform.position = base_pos + new Vector3(0, temp_inc_water_value * 10, 0);
        //Debug.Log(list_index);
        slr_text.text = ("This is the simulation of " + slr_data_list[list_index][0] + ", the SL is: " + temp_inc_water_value + ". Scenario: RCP" + mapRCPName);
        
        //Debug.Log(slr_text.text);

    }

    private void changeGraphPic()
    {
        if (pressAAAction.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
        {
            laser_handler.graphPic.inc_index();
            laser_handler.graphPic.butActivate();
        }
        if (pressAAAction.GetLastStateDown(SteamVR_Input_Sources.RightHand))
        {
            laser_handler.graphPic.dec_index();
            laser_handler.graphPic.butActivate();
        }
    }

    public static void setWaterValue(int index)
    {
        temp_inc_water_value = slr_data_list[index][1];
        water_mean_value = slr_data_list[index][1];
        water_min_value = slr_data_list[index][2];
        water_max_value = slr_data_list[index][3];
    }

    public static void setSLRdatabase(string RCPName)
    {
        mapRCPName = RCPName;
        slr_data = new SLR_data_handling(RCPName);
        slr_data_list = slr_data.getSLRList();
        setWaterValue(0);
    }
}

