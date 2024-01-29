using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    [Header("sprites")]
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer srenderer;

    [Header("rotation")]
    [SerializeField]private float randomRotationOffset;
    [SerializeField]private float rotationOffset;

    [Header("position")]
    [SerializeField]private float randomPositionOffset;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = playerController.instance.gameObject;

        srenderer = GetComponent<SpriteRenderer>();

        srenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        rotationOffset = Random.Range(-randomRotationOffset, randomRotationOffset);

        Vector3 positionOffset = new Vector3(Random.Range(-randomPositionOffset, randomPositionOffset),0 , Random.Range(-randomPositionOffset, randomPositionOffset));

        transform.position = transform.position + positionOffset;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Get the direction from this GameObject to the target GameObject
            Vector3 directionToTarget = player.transform.position - transform.position;

            // Set the Y rotation based on the direction and add the offset
            float targetRotationY = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg + rotationOffset;
            Quaternion targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);

            // Smoothly rotate only the Y rotation towards the target
            float rotationSpeed = 5f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target object reference not set in the DirectionBetweenObjects script!");
        }
    }
}