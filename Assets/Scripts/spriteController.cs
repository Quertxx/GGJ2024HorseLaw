using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteController : MonoBehaviour
{
    Image sprite;
    Color baseColor = new Vector4(1f,1f,1f,1f);
    Color highlightColor;
    Color outOfFocusColor = new Vector4(0.5f,0.5f,0.5f,1f);
    public Gradient fadeIn; //gray to white
    public Gradient fadeOut; //white to gray
    public Gradient completeFadeIn; //alpha 0 to alpha 100
    public Gradient completeFadeOut; //alpha 100 to alpha 0
    public Sprite[] expressions;

    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            FadeInCompletely();
        }
    }
    public void FadeIn() //used to transition from OutOfFocus to BaseColor
    {
        StartCoroutine(FadeInLerp());
    }

    IEnumerator FadeInLerp()
    {
        for (int x = 0; x < 100; x++)
        {
            sprite.color = fadeIn.Evaluate((float)x / 100);
            Debug.Log(sprite.color);
            yield return new WaitForSeconds(0.02f);
        }   
    }

    public void FadeOut() //used to transition from BaseColor to OutOfFocus
    {
        StartCoroutine(FadeOutLerp());
    }

    IEnumerator FadeOutLerp()
    {
        for (int x = 0; x < 100; x++)
        {
            sprite.color = fadeOut.Evaluate((float)x / 100);
            Debug.Log(sprite.color);
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void FadeInCompletely() //used to fade the sprite in from not being visible
    {
        StartCoroutine(FadeInCompletelyLerp());
    }

    IEnumerator FadeInCompletelyLerp()
    {
        for (int x = 0; x < 100; x++)
        {
            sprite.color = completeFadeIn.Evaluate((float)x / 100);
            Debug.Log(sprite.color);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void FadeOutCompletely() //used to fade sprite out to not being visible
    {
        StartCoroutine(FadeOutCompletelyLerp());
    }

    IEnumerator FadeOutCompletelyLerp()
    {
        for (int x = 0; x < 100; x++)
        {
            sprite.color = completeFadeOut.Evaluate((float)x / 100);
            Debug.Log(sprite.color);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void Disappear() //used to make a sprite disappear immediately with no fading
    {
        sprite.color = new Vector4(0f,0f,0f,0f);
    }

    public void Appear() //used to make a sprite appear immediately with no fading
    {
        sprite.color = baseColor;
    }

    public void Base()
    {
        sprite.sprite = expressions[0];
    }

    public void Anger()
    {
        sprite.sprite = expressions[1];
    }

    public void Axe()
    {
        sprite.sprite = expressions[2];
    }

    public void Confuse()
    {
        sprite.sprite = expressions[3];
    }

    public void Depress()
    {
        sprite.sprite = expressions[4];
    }

    public void Shock()
    {
        sprite.sprite = expressions[5];
    }

    public void Smirk()
    {
        sprite.sprite = expressions[6];
    }

    public void Smug()
    {
        sprite.sprite = expressions[7];
    }

    public void Worry()
    {
        sprite.sprite = expressions[8];
    }
}
