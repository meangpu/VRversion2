using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool useController = false;

    public List<GameObject> controllerPrefabs;
    public GameObject handPrefab;
    public InputDeviceCharacteristics controllerChar;


    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnim;


    private void Start() 
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChar, devices);

        foreach (var item in devices)
        {
            Debug.Log($"{item.name} / {item.characteristics}");
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("can't find controller prefabs");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handPrefab, transform);
            handAnim = spawnedHandModel.GetComponent<Animator>();
        }  
    }

    void UpdateHandAnim()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnim.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnim.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnim.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnim.SetFloat("Grip", 0);
        }
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (useController)
            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnim();
            }
        }


    }
}
