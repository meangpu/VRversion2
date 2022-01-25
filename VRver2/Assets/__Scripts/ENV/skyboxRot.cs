using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxRot : MonoBehaviour
{
    [SerializeField] float rotSpeed;


    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotSpeed);
    }
}
