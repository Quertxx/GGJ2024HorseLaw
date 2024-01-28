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
 


    private bool isLookRunning;
    IEnumerator LookForward()
    {
        isLookRunning = true;
        Quaternion target = Quaternion.Euler(0, 11.49f, 0);
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
    public void StartLookForward()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }

        StartCoroutine(LookForward());
        
    }

    public void StartLookRight()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }
        StartCoroutine(LookRight());
    }

    public void StartLookLeft ()
    {
        if (isLookRunning)
        {
            StopAllCoroutines();
            isLookRunning = false;
        }
        StartCoroutine(LookLeft());
    }
}
