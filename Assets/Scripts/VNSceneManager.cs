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
    
    void nextScene()
    {
        //SceneManager.LoadScene();
    }
}
