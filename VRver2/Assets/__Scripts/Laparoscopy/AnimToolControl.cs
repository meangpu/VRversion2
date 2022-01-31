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
    [SerializeField] MoverHead moveHeadScpt;
    private string cutStateNow;
    private string moveStateNow;

    const string CUT = "cut";
    const string HOLD = "hold";
    const string IDLE = "idle";
    const string MOVE = "move";


    [ContextMenu("Hold")]
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
            moveHeadScpt.disableMove();
            // moveAnimControl.SetTrigger("Hold");
        }
        
    }

    [ContextMenu("Cut")]
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
            moveHeadScpt.enableMove();
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
