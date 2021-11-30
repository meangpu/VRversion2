using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGetCutRope : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "CutCollider")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}
