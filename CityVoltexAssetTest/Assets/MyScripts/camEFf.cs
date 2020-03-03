using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camEFf : MonoBehaviour
{
    public float waterlevel;
    private bool isUnderwater;
    private Color normal_color;
    private Color underwater_color;
    // Start is called before the first frame update
    void Start()
    {
        isUnderwater = false;
        normal_color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwater_color = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < waterlevel) != isUnderwater){
            isUnderwater = transform.position.y < waterlevel;
            if (isUnderwater) setUnderWater();
            if (!isUnderwater) setNormal();
        }
    }
    void setNormal()
    {
        Debug.Log("Normal");
        RenderSettings.fogColor = normal_color;
        RenderSettings.fogDensity = 0.22f;
    }

    void setUnderWater()
    {
        Debug.Log("Underwater");
        RenderSettings.fogColor = normal_color;
        RenderSettings.fogDensity = 0.222f;
    }
}
