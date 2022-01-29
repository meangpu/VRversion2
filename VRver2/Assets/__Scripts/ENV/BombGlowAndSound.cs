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
        if (state != GameState.Playing)
        {
            return;
        }
        else
        {
            isRed = true;
            StartCoroutine(doTickBomb());
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
            meshRender.material = greenGlow;
            yield return null;
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
}


