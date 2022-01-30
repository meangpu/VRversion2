using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;


public class AnimToolControl : MonoBehaviour
{
    [SerializeField] Animator cutAnimControl;
    [SerializeField] Animator moveAnimControl;
    [SerializeField] HeadSelector headScpt;
    private string cutStateNow;
    private string moveStateNow;

    const string CUT = "cut";
    const string HOLD = "hold";
    const string IDLE = "idle";
    const string MOVE = "move";

    public void playholdAnim()
    {
        if (headScpt.toolID == 0)  // 0 = scissor
        {
            ChangeAnimCutState(HOLD);
            // cutAnimControl.SetTrigger("Hold");
        }
        else if (headScpt.toolID == 1)
        {
            ChangeAnimMoveState(HOLD);
            // moveAnimControl.SetTrigger("Hold");
        }
        
    }

    public void playCutAnim()
    {
        if (headScpt.toolID == 0)  // 0 = scissor
        {
            ChangeAnimCutState(CUT);
            // cutAnimControl.SetTrigger("Cut");
        }
        else if (headScpt.toolID == 1)
        {
            ChangeAnimMoveState(MOVE);
            // moveAnimControl.SetTrigger("Action");
        }
    }

    void ChangeAnimCutState(string newState)
    {
        if(cutStateNow == newState) return;
        cutAnimControl.Play(newState);
        cutStateNow = newState;
    }

    void ChangeAnimMoveState(string newState)
    {
        if(moveStateNow == newState) return;
        moveAnimControl.Play(newState);
        moveStateNow = newState;
    }



}
