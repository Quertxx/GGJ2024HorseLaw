using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VNSceneManager : MonoBehaviour
{
    public GameObject dialogue;

    // Start is called before the first frame update
    void Awake()
    {
        dialogue.SetActive(true);
    }
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void nextScene()
    {
        SceneManager.LoadScene(3);
    }

    public void mainMenu()
    {
        Debug.Log("ye");
        SceneManager.LoadScene(0);
    }
}
