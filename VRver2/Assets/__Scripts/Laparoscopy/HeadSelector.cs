using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class HeadSelector : MonoBehaviour
{
    [SerializeField] GameObject scissorObj; 
    [SerializeField] GameObject moverObj; 
    [SerializeField] AnimToolControl toolScpt;

    [Header("XRSetting")]
    public XRNode inputSource;
    private InputDevice device;

    [Header("ToolText")]
    [SerializeField] TMP_Text scissorText;
    [SerializeField] TMP_Text moverText;

    [Header("ToolChange")]
    public int toolID = 0;
    public float maxCD = 1;
    private float cd = 1;

    InputDevice targetDevice;
    bool pressState;

    private void Start() 
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);
    }

    void Update()
    {
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out pressState))
        {
            if (pressState && cd <= 0)
            {
                cd = maxCD;
                addNumberToId();
                pressState = false;
            }
            cd -= Time.deltaTime;
        }
    }


    public void selScissor()
    {
        moverObj.SetActive(false);
        scissorObj.SetActive(true);
    }

    public void selMover()
    {
        scissorObj.SetActive(false);
        moverObj.SetActive(true);
    }

    [ContextMenu("Change Tool Head")]
    public void addNumberToId()
    {
        toolID++;
        if (toolID > 1)
        {
            toolID = 0;
        }

        if (toolID == 0)
        {
            selScissor();
            StartCoroutine(showScissorText());
        }
        else if (toolID == 1)
        {
            selMover();
            StartCoroutine(showMoverText());
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
