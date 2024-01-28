using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AI_Detection : MonoBehaviour
{
    [Range(0,1)] public float detection;
    public Slider detectionBar;
    [SerializeField] public static AI_Detection instance;

    public float detectionSpeed;
    public float detectionDecreaseSpeed;

    public bool isBeingDetected;

    public float diePercent;

    public Image deathOverlay;


    public GameObject playerCollider;
    public List<AI_Controller> detections;
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
    private void Update()
    {
        NewNewDetection();
    }
    void NewNewDetection()
    {
        int countNumber = 0;
        float detectionIncrease = 0;
        foreach (AI_Controller detection in detections)
        {
            float temp = detection.lineOfSightSensor.GetResult(playerCollider).Visibility;
            if (temp > 0)
            {
                countNumber++;
                detectionIncrease += detection.lineOfSightSensor.GetResult(playerCollider).Visibility;
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

        if (detection >= diePercent && !isdead)
        {
            deathOverlay.gameObject.SetActive(true);
            //Time.timeScale = 1;
            StartCoroutine(Die());
        }
    }
    private bool isdead = false;

    private IEnumerator Die()
    {
        isdead = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void AddToList(AI_Controller controller)
    {
        detections.Add(controller);
    }

    public void RemoveFromList(AI_Controller controler)
    {
        detections.Remove(controler);
    }
}

[System.Serializable]
public class IndividualDetection
{
    public AI_Controller controller;
}
