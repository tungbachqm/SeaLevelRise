using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_height : MonoBehaviour
{
    public float added_height = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, added_height, transform.position.z);

    }

    public void adjustHeight(float new_height)
    {
        added_height = new_height;
    }
}
