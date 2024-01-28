using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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



    public GameObject playerCollider;
    public List<IndividualDetection> detections;
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

    //void NewDetection()
    //{

    //    if (numberOfDetects > 0)
    //    {
    //        float detectionIncrease = 0;
    //        foreach (IndividualDetection detection in detections)
    //        {
    //            detectionIncrease += detection.controller.lineOfSightSensor.GetResult(playerCollider).Visibility;
    //        }

    //        detectionIncrease = detectionIncrease * Time.deltaTime * detectionSpeed;
    //        detection = Mathf.Clamp(detection + detectionIncrease, 0, 1);
    //    }
    //    else
    //    {
    //        detection = Mathf.Clamp(detection - detectionDecreaseSpeed * Time.deltaTime, 0, 1);
    //    }

    //    detectionBar.value = detection;
    //}

    private void Update()
    {
        NewNewDetection();
    }
    void NewNewDetection()
    {
        int countNumber = 0;
        float detectionIncrease = 0;
        foreach (IndividualDetection detection in detections)
        {
            float temp = detection.controller.lineOfSightSensor.GetResult(playerCollider).Visibility;
            if (temp > 0)
            {
                countNumber++;
                detectionIncrease += detection.controller.lineOfSightSensor.GetResult(playerCollider).Visibility;
            }
        }
        if (countNumber > 0)
        {
            detectionIncrease = detectionIncrease * Time.deltaTime * detectionSpeed;
            detection = Mathf.Clamp(detection + detectionIncrease, 0, 1);
        }
        else
        {
            detection = Mathf.Clamp(detection - detectionDecreaseSpeed * Time.deltaTime, 0, 1);
        }
        detectionBar.value = detection;
    }

    public void AddToList(AI_Controller controller)
    {
        IndividualDetection newAdd = new IndividualDetection();
        newAdd.controller = controller;


        detections.Add(newAdd);
    }

    public void RemoveFromList(AI_Controller controler)
    {
        foreach (IndividualDetection detection in detections)
        {
            if (detection.controller == controler)
            {
                detections.Remove(detection);
            }
        }
    }
}

[System.Serializable]
public class IndividualDetection
{
    public AI_Controller controller;
    public bool seesThePlayer;
}
