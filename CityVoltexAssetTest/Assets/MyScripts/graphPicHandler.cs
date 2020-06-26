using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphPicHandler : MonoBehaviour
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
    private int index = 0;
    private GameObject[] graph_list;
    private List<string> graph_col_name;
    public graphPicHandler()
    {
        parent_obj = GameObject.Find("AreaLayer");
        graph_col_name = new List<string>();
        graph_list = GameObject.FindGameObjectsWithTag("GraphPic");
        GameObject[] graph_col_l = GameObject.FindGameObjectsWithTag("GraphPicCol");
        foreach (GameObject obj in graph_list)
        {
            Debug.Log("Hello, I am" + obj.name);
        }

        foreach (GameObject obj in graph_col_l)
        {
            graph_col_name.Add(obj.name);
            Debug.Log("THis is graph_col" + obj.name);
        }
        
        this.deactivate();
    }

    public void activate()
    {
        parent_obj.SetActive(true);
    }

    public void deactivate()
    {
        parent_obj.SetActive(false);
    }

    public void butActivate()
    {
        this.butDeactivate();
        Debug.Log("The index is " + index);
        graph_list[index].SetActive(true);
    }

    public void butDeactivate()
    {
        foreach (GameObject obj in graph_list)
        {
            obj.SetActive(false);
        }
    }

    public List<string> getGraphColNameList()
    {
        return graph_col_name;
    }

    public void inc_index()
    {
        if (index < graph_list.Length - 1)
        {
            index++;
        }

    }

    public void dec_index()
    {
        if (index > 0)
        {
            index--;
        }
    }
}
