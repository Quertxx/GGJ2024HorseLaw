using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VNSceneManager : MonoBehaviour
{
    public GameObject dialogue;
    private AudioSource music;

    // Start is called before the first frame update
    void Awake()
    {
        //if (dialogue != null)
        //{
        //    dialogue.SetActive(true);
        //}
        music = GetComponent<AudioSource>();
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
        StartCoroutine(delaythenchangeScene());
    }

    IEnumerator delaythenchangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
