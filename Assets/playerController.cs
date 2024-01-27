using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private GameObject playerRef;
    private Rigidbody playerRB;
    private Rigidbody playerRB2;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = gameObject.transform.GetChild(0).gameObject;
        playerRB = GetComponent<Rigidbody>();
        playerRB2 = playerRef.GetComponent<Rigidbody>();
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
        playerRB.velocity = new Vector3(desiredDirecton.x * speed, playerRB2.velocity.y, desiredDirecton.z * speed);
        playerRB2.velocity = new Vector3(desiredDirecton.x * speed, playerRB2.velocity.y, desiredDirecton.z * speed);
    }
}
