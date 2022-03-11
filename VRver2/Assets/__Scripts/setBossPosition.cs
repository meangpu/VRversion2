using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setBossPosition : MonoBehaviour
{
    [SerializeField] Vector3 posValue = new Vector3(-0.0205061883f,1.4633683f,1.21283424f);
    [SerializeField] Vector3 rotEul;
   
    public void DoSetPP() 
    {
        transform.position = posValue;
        transform.rotation = Quaternion.Euler(rotEul);;

    }
}
