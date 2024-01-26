using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private Rigidbody playerRB;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();


        Vector3 desiredDirecton = forward * axisY + right * axisX;
        //transform.rotation = Quaternion.LookRotation(forward);
        //transform.Translate(desiredDirecton * speed * Time.deltaTime);
        playerRB.velocity = desiredDirecton * speed;
    }
}
