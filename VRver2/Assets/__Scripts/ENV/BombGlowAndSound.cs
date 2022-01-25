using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BombGlowAndSound : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRender;
    [SerializeField] Material redGlow;
    [SerializeField] Material whiteGlow;
    [SerializeField] Material greenGlow;
    [SerializeField] AudioSource beepSound;
    [SerializeField] bool isRed;

    public async void doTickBomb()
    {
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
        doTickBomb();
    }

    private void Start() 
    {
        doTickBomb();
    }


    







}
