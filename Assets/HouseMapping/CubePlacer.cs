using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CubePlacer : MonoBehaviour
{
    OSC osc;
    XRCustomController controller;

    void Awake()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC));
        controller = GetComponent<XRCustomController>();

        //trigger the Place_Cube Function when the trigger is pressed
        //controller.activateAction.action.performed += Place_Cube;
        controller.secondaryButtonAction.action.performed += Place_Cube;
    }

    private void Place_Cube(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Cube Placed");

        //create a new cube, scale it, and position it where the controller is
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        cube.transform.position = this.transform.position;

        //networking message
        OscMessage message = new OscMessage();
        message.address = "/newPoint";
        message.values.Add(cube.transform.position.x);
        message.values.Add(cube.transform.position.y);
        message.values.Add(cube.transform.position.z);
        osc.Send(message);
    }
}




