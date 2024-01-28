using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Micosmo.SensorToolkit;


[RequireComponent(typeof(AI_Movement))]
public class AI_Controller : MonoBehaviour
{
    public LOSSensor lineOfSightSensor;
    public Sensor rangeSensor;
    public AI_Movement movement;

    [Header("Stats")]
    public float reactionTime;

    public MovementType movementType;
    public enum MovementType
    {
        Spin,
        Idle,
        Patrol,
        SpinPatrol,
    }

    public bool willChase;

    [Header("Sprites")]
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private bool isTom;

    [Header("Sounds")]
    [SerializeField] private AudioClip defaultSpotSound;
    [SerializeField] private AudioClip[] tomSpotSounds;
    private AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        ReturnToDefaultMovement();

        soundSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            soundSource.clip = defaultSpotSound;
        }
        else
        {
            isTom = true;
            RandomTomSound();
        }
    }

    private void RandomTomSound()
    {
        soundSource.clip = tomSpotSounds[Random.Range(0, tomSpotSounds.Length)];
    }

    private void ReturnToDefaultMovement()
    {
        StopAllCoroutines();
        StartCoroutine(DefaultMovement());
    }
    private IEnumerator DefaultMovement()
    {
        //set movement to idle
        movement.setIdle();

        yield return new WaitForSecondsRealtime(reactionTime);

        switch (movementType)
        {
            case MovementType.Idle:
                movement.setIdle();
                break;
            case MovementType.Patrol:
                movement.setPatrol();
                break;
            case MovementType.Spin:
                movement.setSpin();
                break;
            case MovementType.SpinPatrol:
                movement.setSpinPatrol();
                break;
        }

        yield break;
    }

    public void PlayerEnterRange()
    {
        AI_Detection.instance.AddToList(this);
        Debug.Log(AI_Detection.instance.gameObject);
    }

    public void PlayerExitRange()
    {
        AI_Detection.instance.RemoveFromList(this);
    }


    private IEnumerator PLayerEnterLos()
    {
        if (willChase)
        {
            //set movement to idle
            movement.setIdle();
            yield return new WaitForSecondsRealtime(reactionTime);
            movement.setChase();
        }
    }

    public void PlayerEnterLOS()
    {
        StartCoroutine(PLayerEnterLos());

        if (isTom)
        {
            RandomTomSound();
        }

        soundSource.Play();
    }

    public void PlayerLeaveLOS()
    {
        ReturnToDefaultMovement();
    }

    public float GetPlayerVisibility()
    {
        return lineOfSightSensor.GetResult(playerController.instance.playerCollider).Visibility;
    }
}
