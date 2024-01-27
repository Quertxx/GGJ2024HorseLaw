using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDialogue : MonoBehaviour
{

    public GameObject flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            flowchart.SetActive(true);
        }
    }
}
