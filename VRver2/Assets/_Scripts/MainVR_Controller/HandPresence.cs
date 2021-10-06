using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] GameObject rotateHead;
    [SerializeField] float rotSpeed;
    [SerializeField] float nowAngle = 0;

    InputDevice targetDevice;
    Vector2 rotate2DValue;

    private void Start() 
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out rotate2DValue) && rotate2DValue != Vector2.zero)
        {
            nowAngle -= rotate2DValue.x * rotSpeed;
            rotateHead.transform.localRotation = Quaternion.Euler(nowAngle, 0, 0);
        }
    }
}
