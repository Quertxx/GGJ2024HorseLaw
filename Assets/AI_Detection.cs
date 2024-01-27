using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Detection : MonoBehaviour
{
    public float detection;
    public Slider detectionBar;
    [SerializeField] public static AI_Detection instance;

    public float detectionSpeed;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void IncreaseDetection(float detectionAmmount)
    {
        Debug.Log("final test " + detectionAmmount );
        detection += detectionAmmount * detectionSpeed;
    }
}
