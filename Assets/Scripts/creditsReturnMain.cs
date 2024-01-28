using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class creditsReturnMain : MonoBehaviour
{
    UnityEvent jumpScare = new UnityEvent();
    Animator horseAnimator;
    // Start is called before the first frame update
    void Start()
    {
        jumpScare.AddListener(MainMenu);
        horseAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!AnimatorIsPlaying())
        {
            jumpScare.Invoke();
        }
    }

    // Update is called once per frame
    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    bool AnimatorIsPlaying()
    {
        return horseAnimator.GetCurrentAnimatorStateInfo(0).length >
               horseAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
