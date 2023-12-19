using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject VRCamera;
    [SerializeField]
    private GameObject PCCamera;

    private List<InputDevice> inputDevices = new List<InputDevice>();
    // Start is called before the first frame update
    void Start()
    {
        InputDevices.GetDevices(inputDevices);
        CheckHmdUsage();
    }
    // Update is called once per frame
    void Update()
    {
        CheckHmdUsage();

    }

    private void CheckHmdUsage()
    {
        if (inputDevices[0].isValid)
        {
            if (inputDevices[0].TryGetFeatureValue(CommonUsages.userPresence, out bool hmdBeingUsed) && hmdBeingUsed)
            {

                VRCamera.SetActive(true);
                PCCamera.SetActive(false);
            }
            else
            {
                VRCamera.SetActive(false);
                PCCamera.SetActive(true);
            }
        }
        else
        {
            VRCamera.SetActive(false);
            PCCamera.SetActive(true);
        }
    }


}
