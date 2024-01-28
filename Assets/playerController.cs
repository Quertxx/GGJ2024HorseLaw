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

    [Header("make sure its linked")]
    public static playerController instance;
    public GameObject playerCollider;

    [Header("sounds")]
    [SerializeField] float moveSoundTime;
    public AudioClip[] moveSounds;
    private AudioSource playerAudioSource;

    private void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = gameObject.GetComponent<AudioSource>();
        playerRef = gameObject.transform.GetChild(0).gameObject;
        playerRB = gameObject.GetComponent<Rigidbody>();
        //playerRB2 = playerRef.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = Camera.main;

        InvokeRepeating("SoundShit", moveSoundTime, moveSoundTime);
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
        playerRB.velocity = new Vector3(desiredDirecton.x * speed, playerRB.velocity.y, desiredDirecton.z * speed);
        //playerRB2.velocity = new Vector3(desiredDirecton.x * speed, playerRB2.velocity.y, desiredDirecton.z * speed);

        
    }

    private void SoundShit()
    {
        if (playerRB.velocity.magnitude >= 1)
        {
            playerAudioSource.clip = moveSounds[Random.Range(0, moveSounds.Length-1)];
            playerAudioSource.Play();
        }
    }
}
