using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelInfoOpenClose : MonoBehaviour
{

    public void openAndCloseAllOtherNewBetter(GameObject openOne)
    { 
        GameObject[] allClose = GameObject.FindGameObjectsWithTag("InfoPanel");
        foreach (GameObject ga in allClose)
        {
            ga.SetActive(false);
        }
        openOne.SetActive(true);
    }

}
