using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fungusCameraControl : MonoBehaviour
{
    public float turnAngle = 40f;
    public float turnSpeed = 1f;

    public Transform right;
    public Transform left;
    public Transform forward;
 

    private void Awake()
    {

    }

    private void Update() //debugging, remove before build
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartLookLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartLookRight();
        }
    }

    private bool isLookRunning;
    IEnumerator LookForward()
    {
        isLookRunning = true;
        Quaternion target = Quaternion.Euler(0, 0, 0);
        while (transform.rotation != target)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, turnSpeed);
            yield return null;
        }
    }

    IEnumerator LookRight()
    {
        isLookRunning = true;
        Quaternion target = Quaternion.Euler(0, turnAngle, 0);
        while (transform.rotation != target)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, turnSpeed);
            yield return null;
        }
    }

    IEnumerator LookLeft()
    {
        isLookRunning = true;
        Quaternion target = Quaternion.Euler(0, -turnAngle, 0);
        while (transform.rotation != target)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, turnSpeed);
            yield return null;
        }
    }
    void StartLookForward()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }

        StartCoroutine(LookForward());
        
    }

    void StartLookRight()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }
        StartCoroutine(LookRight());
    }

    void StartLookLeft ()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }
        StartCoroutine(LookLeft());
    }
}
