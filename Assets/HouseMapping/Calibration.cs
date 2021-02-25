
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Calibration : MonoBehaviour
{
    public Transform handAnchor;  //the controller on the hand
    public Transform worldAnchor; //the fixed controller
    private XRCustomController controller;

    [SerializeField] Transform XRRig = null;

    private void Awake()
    {
        worldAnchor = GameObject.FindGameObjectWithTag("WorldAnchor").transform;
        controller = GetComponent<XRCustomController>();

        //trigger the Place_Cube Function when the trigger is pressed
        //controller.selectAction.action.performed += Calibrate;
        controller.primaryButtonAction.action.performed += Calibrate;
    }

    private void Calibrate(InputAction.CallbackContext obj)
    {
        
        Vector3 posOffset = worldAnchor.position - handAnchor.position; //calculate the difference in positions

        //remove y offset (keep floor height the same)
        posOffset.y = 0;

        XRRig.position += posOffset; //offset the position of the cameraRig to realign the controllers

        Vector3 rotOffset = worldAnchor.eulerAngles - handAnchor.eulerAngles; //calculate the difference in rotations
        XRRig.RotateAround(handAnchor.position, Vector3.up, rotOffset.y); //using the hand as a pivot, rotate around Y


        Debug.Log("CALIBRATED");
        Debug.Log("Position offset: " + posOffset);
        Debug.Log("Rotation offset: " + rotOffset);
    }
}