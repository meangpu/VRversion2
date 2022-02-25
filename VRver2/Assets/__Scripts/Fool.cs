using UnityEngine;
using UnityEngine.XR;

public class Fool : MonoBehaviour
{

	[Header("XRSetting")]
    public XRNode inputSource;
    private InputDevice device;
    bool pressState;
    private bool lastButtonState = false;

    private void Start() 
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);
    }

    void Update()
    {
        // device.TryGetFeatureUsages(CommonUsages.primaryTouch, out pressState);
        // device.TryGetFeatureValue(CommonUsages.primaryButton, out pressState);  // a press


        // bool tempState = false;
        // bool primaryButtonState = false;
        // tempState = device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState); // did get a value
        //             // && primaryButtonState // the value we got
        //             // || tempState; // cumulative result from other controllers
        

        // if (tempState != lastButtonState) // Button state changed since last frame
        // {
        //     Debug.LogFormat("true");
        //     lastButtonState = tempState;
        // }
        // else 
        // {
        //     Debug.Log("False");
        // }


        // Debug.Log(pressState);
        // Debug.Log(Input.GetKeyDown(KeyCode.Return));
		// Debug.Log(Input.GetKeyUp(KeyCode.Return));
    }
}
