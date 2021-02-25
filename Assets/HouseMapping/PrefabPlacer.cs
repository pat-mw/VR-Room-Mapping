using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class PrefabPlacer : MonoBehaviour
{
    OSC osc;
    [SerializeField] InputActionProperty secondaryButtonAction;

    [SerializeField] GameObject m_prefab = null;
    [SerializeField] Transform prefabSocket;

    void Start()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC));

        //trigger the Place_Cube Function when the trigger is pressed
        //controller.activateAction.action.performed += Place_Cube;
        secondaryButtonAction.action.performed += Place_Cube;
    }

    private void Place_Cube(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Prefab Placed");

        //create a new prefab and position it where the controller is
        GameObject prefab = Instantiate(m_prefab);
        prefab.transform.position = prefabSocket.position;

        //networking message
        OscMessage message = new OscMessage();
        message.address = "/newPoint";
        message.values.Add(prefab.transform.position.x);
        message.values.Add(prefab.transform.position.y);
        message.values.Add(prefab.transform.position.z);
        osc.Send(message);
    }
}

