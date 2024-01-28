using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenuParent;
    public GameObject creditsParent;
    public GameObject controlsParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Application.Quit();
    }
    public void credits()
    {
        SceneManager.LoadScene(1);
    }
    public void hideCredits()
    {
        MainMenuParent.SetActive(true);
        creditsParent.SetActive(false);
    }
    public void hideControls()
    {
        MainMenuParent.SetActive(true);
        controlsParent.SetActive(false);
    }
    public void controls()
    {
        MainMenuParent.SetActive(false);
        controlsParent.SetActive(true);
    }
}
