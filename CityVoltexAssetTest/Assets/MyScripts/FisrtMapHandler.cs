using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisrtMapHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private GameObject parent_obj;
    private GameObject[] maps;
    private GameObject[] mapCols;
    private List<string> mapColsName;
    public FisrtMapHandler()
    {
        parent_obj = GameObject.Find("ScenariosLayer");
        mapColsName = new List<string>();
        maps = GameObject.FindGameObjectsWithTag("1st_Layout_map");
        mapCols = GameObject.FindGameObjectsWithTag("MapCol");

        foreach (GameObject obj in mapCols)
        {
            mapColsName.Add(obj.name);
        }
    }

    public GameObject[] getMapList()
    {
        return maps;
    }

    public List<string> getMapColsName()
    {
        return mapColsName;
    }

    public void activate()
    {
        parent_obj.SetActive(true);
    }

    public void deactivate()
    {
        parent_obj.SetActive(false);

    }

    public void sceneNameActivate()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(true);
        }
    }

    public void sceneNameDeActivate()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }
    }
}
