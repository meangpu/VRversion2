using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHand : MonoBehaviour
{
    [SerializeField] GameObject LeftHandMain;
    [SerializeField] GameObject RightHandMain;

    [SerializeField] MeshRenderer mainMesh;
    [SerializeField] Material notGlow;
    [SerializeField] Material Glow;
    [SerializeField] GameObject MainLight;

    bool nowBoolean = false;

    HandPresence leftScpt;
    HandPresence rightScpt;

    void setup()
    {
        leftScpt = LeftHandMain.transform.GetChild(0).GetComponent<HandPresence>();
        rightScpt = RightHandMain.transform.GetChild(0).GetComponent<HandPresence>();
    }

    public void switchHand()
    {
        nowBoolean = !nowBoolean;
        setup();
        leftScpt.useController = !leftScpt.useController;
        rightScpt.useController = !rightScpt.useController;

        MainLight.SetActive(nowBoolean);

        if (nowBoolean)
        {
            mainMesh.material = Glow;
        }
        else
        {
            mainMesh.material = notGlow;
        }
        
    }


}
