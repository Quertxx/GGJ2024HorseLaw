using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Detection : MonoBehaviour
{
    [Range(0,1)]public float detection;
    public Slider detectionBar;
    [SerializeField] public static AI_Detection instance;

    public float detectionSpeed;
    public float detectionDecreaseSpeed;

    public bool isBeingDetected;

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
        isBeingDetected = true;
        Debug.Log("final test " + detectionAmmount );
        float detectionIncrease = detectionAmmount * detectionSpeed;
        detection += detectionIncrease;

        if (detectionIncrease <= 0.001)
        {
            StopDetection();
        }
    }

    public void StopDetection()
    {
        isBeingDetected = false;
    }

    private void Update()
    {
        if (!isBeingDetected)
        {
            detection -= detectionDecreaseSpeed * Time.deltaTime;
        }
    }
}
