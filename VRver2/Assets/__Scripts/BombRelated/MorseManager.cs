using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] float timeNextLoop = 1;
    [SerializeField] float timeInLoop = .2f;
    [SerializeField] float timeShort = .3f;
    [SerializeField] float timeLong = .6f;

    [SerializeField] MeshRenderer lightObject;
    [SerializeField] AudioSource shortSound;
    [SerializeField] AudioSource longSound;

    [SerializeField] Material matLightOn;
    [SerializeField] Material matLightOff;

    [Header("main")]
    [SerializeField] string mainMorseWord;
    private IEnumerator coroutine;

   private void Awake() 
    {
        GameManager.OnGameStateChange += HandleGameManagerChangeState;
    }

    private void OnDestroy() 
    {
        GameManager.OnGameStateChange -= HandleGameManagerChangeState;
    }


    void HandleGameManagerChangeState(GameState state)
    {
        if (state != GameState.Playing && state != GameState.Wingame && state != GameState.Losegame)
        {
            return;
        }
        else
        {
            if(state == GameState.Playing)
            {
                StartCoroutine(coroutine);
            }

            else if(state == GameState.Wingame)
            {
                StartCoroutine(coroutine);
            }

            else if(state == GameState.Losegame)
            {
                StartCoroutine(coroutine);
            }
        }
    }


    private void Start() 
    {
        coroutine = doStartMorse();
        // StartCoroutine(coroutine);
    }

    public IEnumerator doStartMorse()
    {
        foreach(char c in mainMorseWord)
        {
            if(c.ToString() == ".")
            {
                shortSound.Play();
                turnLightOn();
                yield return new WaitForSeconds(timeShort);
                turnLightOff();
            }
            else if (c.ToString() == "-")
            {
                longSound.Play();
                turnLightOn();
                yield return new WaitForSeconds(timeLong);
                turnLightOff();
            }
            yield return new WaitForSeconds(timeInLoop);
        }

        yield return new WaitForSeconds(timeNextLoop);
        StartCoroutine(doStartMorse());
        
    }

    void turnLightOn()
    {
        lightObject.material = matLightOn;
    }

    void turnLightOff()
    {
        lightObject.material = matLightOff;
    }

}
