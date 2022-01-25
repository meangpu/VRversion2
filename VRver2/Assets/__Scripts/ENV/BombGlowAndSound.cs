using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class BombGlowAndSound : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRender;
    [SerializeField] Material redGlow;
    [SerializeField] Material whiteGlow;
    [SerializeField] Material greenGlow;
    [SerializeField] AudioSource beepSound;
    [SerializeField] bool isRed;
    CancellationTokenSource _tokenSource = null;

    public async void doTickBomb()
    {
        _tokenSource = new CancellationTokenSource();
        var token = _tokenSource.Token;



        if (!isRed)
        {
            meshRender.material = greenGlow;
            return;
        }
        else  // is red tick
        {
            beepSound.Play();
            meshRender.material = redGlow;
            await Task.Delay(700);
            meshRender.material = whiteGlow;
            await Task.Delay(210);
        }
        await Task.Yield();

        if(token.IsCancellationRequested)
        {
            return;   
        }
        doTickBomb();
    }

    private void Start() 
    {
        doTickBomb();
    }


    







}
