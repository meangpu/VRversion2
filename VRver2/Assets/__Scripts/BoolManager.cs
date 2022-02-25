using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolManager : MonoBehaviour
{
    public bool isButtonBOOL;

    public void CHANGE_TRUE()
    {
        isButtonBOOL=true;
    }
    public void CHANGE_FALSE()
    {
        isButtonBOOL=false;
    }

}
