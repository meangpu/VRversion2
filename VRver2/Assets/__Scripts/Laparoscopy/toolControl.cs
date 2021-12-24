using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;


public class toolControl : MonoBehaviour
{
    [SerializeField] Animator cutAnimControl;

    [SerializeField] Animator moveAnimControl;

    [SerializeField] HeadSelector headScpt;


    [SerializeField] TMP_Text scissorText;
    [SerializeField] TMP_Text moverText;

    public void playholdAnim()
    {
        if (headScpt.toolID == 0)  // 0 = scissor
        {
            cutAnimControl.SetTrigger("Hold");
        }
        else if (headScpt.toolID == 1)
        {
            moveAnimControl.SetTrigger("Hold");
        }
        
    }

    public void playCutAnim()
    {
        Debug.Log("AAAAAAAAAAAAA");
        if (headScpt.toolID == 0)  // 0 = scissor
        {
            cutAnimControl.SetTrigger("Cut");
        }
        else if (headScpt.toolID == 1)
        {
            moveAnimControl.SetTrigger("Action");
        }
    }


    public IEnumerator showScissorText()
    {
        scissorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        scissorText.gameObject.SetActive(false);
    }

    public IEnumerator showMoverText()
    {
        moverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        moverText.gameObject.SetActive(false);
    }

}
