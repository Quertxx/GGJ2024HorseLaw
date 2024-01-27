using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Detection : MonoBehaviour
{
    [Range(0,1)] public float detection;
    public Slider detectionBar;
    [SerializeField] public static AI_Detection instance;

    public float detectionSpeed;
    public float detectionDecreaseSpeed;

    public bool isBeingDetected;




    public List<IndividualDetection> detecions;
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
        float detectionIncrease = detectionAmmount * detectionSpeed * Time.deltaTime;
        Debug.Log(detectionIncrease);
        detection = Mathf.Clamp(detection + detectionIncrease,0,1);
        Debug.Log(detection);
        detectionBar.value = detection;

        if (detectionAmmount == 0)
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
            detection = Mathf.Clamp(detection - detectionDecreaseSpeed * Time.deltaTime, 0, 1);
            detectionBar.value = detection;
        }

        Debug.Log("List has " + ListSpottedAmmount());

    }

    public void AddToList(AI_Controller controler)
    {

    }

    public void RemoveFromList(AI_Controller controler)
    {

    }

    public int ListSpottedAmmount()
    {
        int countNumber =0;
        foreach (IndividualDetection detection in detecions)
        {
            if (detection.seesThePlayer)
            {
                countNumber++;
            }
        }

        return countNumber;
    }
}

[System.Serializable]
public class IndividualDetection
{
    public AI_Controller controller;
    public bool seesThePlayer;
}
