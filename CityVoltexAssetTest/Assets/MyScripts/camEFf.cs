using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camEFf : MonoBehaviour
{
    public GameObject player;
    public GameObject water;
    public GameObject water_projector;
    
 
    private float waterlevel;
    private bool isUnderwater;
    private Color normal_color;
    private Color underwater_color;

    private Material noSkybox;
    //private Material defaultSkybox = RenderSettings.skybox;
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
        waterlevel = water.transform.position.y;
        if ((player.transform.position.y < waterlevel) != isUnderwater){
            isUnderwater = transform.position.y < waterlevel;
            if (isUnderwater) setUnderWater();
            if (!isUnderwater) setNormal();
        }
    }
    void setNormal()
    {
        water_projector.SetActive(false);
        Debug.Log("Normal");
        RenderSettings.fog = false;
        //RenderSettings.fogColor = normal_color;
        //RenderSettings.fogDensity = 0;
        
    }

    void setUnderWater()
    {
        water_projector.SetActive(true);
        RenderSettings.fog = true;
        Debug.Log("Underwater");
        RenderSettings.fogColor = underwater_color;
        RenderSettings.fogDensity = 0.022f;
        
    }
}
