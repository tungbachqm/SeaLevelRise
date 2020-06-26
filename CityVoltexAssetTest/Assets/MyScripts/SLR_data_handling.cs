using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SLR_data_handling : MonoBehaviour
{
    // Start is called before the first frame update
    private List<List<float>> SLR_mean_data;
    private Dictionary<string, string> slr_file_dict;
    void Start()
    {
        
        //SLR_mean_data = loadCsvFile("Assets/SLR test - Sheet1.csv");
        //Debug.Log("This is SLR mean Data " + SLR_mean_data[1][0]);
        //Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public SLR_data_handling(string RCPName)
    {
        this.slr_file_dict = new Dictionary<string, string> { { "8.5", "RCP8.5" }, { "4.5", "RCP4.5" }, { "2.6", "RCP2.6"} };
        Debug.Log("HHHHHHHHHHHHHHHHH" + RCPName);
        Debug.Log(slr_file_dict[RCPName]);

        this.SLR_mean_data = loadCsvFile("Assets/MyResources/SLR_data(csv)/" + "SLR test - " + slr_file_dict[RCPName] + ".csv");
        Debug.Log("This is SLR mean Data " + SLR_mean_data[1][0]);
        //Assets / MyResources / SLR_data(csv) / SLR test - RCP8.5.csv
    }
    public List<List<float>> loadCsvFile(string filePath)
    {
        var reader = new StreamReader(File.OpenRead(filePath));
        List<List<float>> ans = new List<List<float>>();
        while (!reader.EndOfStream)
        {
            
            List<float> temp = new List<float>();
            var line = reader.ReadLine();
            string[] values = line.Split(',');
            foreach (string num in values)
          
            {
                try
                {
                    Debug.Log(num);
                    temp.Add(float.Parse(num));
                }
                catch (System.FormatException)
                {
                    Debug.Log("Hai vl");
                    continue;
                }
            }
            if (temp.Count > 0)
            {
                ans.Add(temp);

            }
            


        }
        Debug.Log("THis is for ans var " + ans[0][1]);
        return ans;
    }
    public List<List<float>> getSLRList()
    {
        return SLR_mean_data;
    }
}
