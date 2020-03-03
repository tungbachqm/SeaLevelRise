using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class editSlider : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    public SteamVR_Action_Boolean sliderEdit;
    public SteamVR_Action_Vector2 touchPadAction;
    public GameObject c_obj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (SteamVR_Input._default.inAtions.newaction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("AL");
        }*/
        if (sliderEdit.GetLastState(SteamVR_Input_Sources.Any))
        {
            print("ZZZ");
            c_obj.transform.position = new Vector3(c_obj.transform.position.x, c_obj.transform.position.y + 1, c_obj.transform.position.z);
        }
        else
        {
            print("AAA");
        }
        Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        print(touchpadValue);
        if (touchpadValue[0] > 0)
        {
            c_obj.transform.position = new Vector3(c_obj.transform.position.x, c_obj.transform.position.y - 1, c_obj.transform.position.z);
        }
        else
        {
            //c_obj.transform.position = new Vector3(c_obj.transform.position.x, c_obj.transform.position.y , c_obj.transform.position.z);
        }
    }
}
