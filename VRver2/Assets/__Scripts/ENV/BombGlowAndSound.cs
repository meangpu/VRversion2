using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombGlowAndSound : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRender;
    [SerializeField] Material redGlow;
    [SerializeField] Material whiteGlow;
    [SerializeField] Material greenGlow;
    [SerializeField] AudioSource beepSound;
    [SerializeField] bool isRed;
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
                isRed = true;
                StartCoroutine(doTickBomb());
            }

            else if(state == GameState.Wingame)
            {
                isRed = false;
                StartCoroutine(doTickBomb());
                changeToGreenMat();
            }

            else if(state == GameState.Losegame)
            {
                isRed = false;
                meshRender.material = redGlow;
            }
        }
    }

    private void Start() 
    {
        coroutine = doTickBomb();
        StartCoroutine(coroutine);
    }


    public IEnumerator doTickBomb()
    {
        if (!isRed)
        {
            changeToGreenMat();
            yield break;
        }
        while (isRed)
        {
            beepSound.Play();
            meshRender.material = redGlow;
            yield return new WaitForSeconds(0.6f);
            meshRender.material = whiteGlow;
            yield return new WaitForSeconds(0.21f);
        }
    }

    public void changeToGreenMat()
    {
        meshRender.material = greenGlow;
    }
}


