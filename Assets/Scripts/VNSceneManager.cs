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
    
    public void nextScene()
    {
        //SceneManager.LoadScene();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
