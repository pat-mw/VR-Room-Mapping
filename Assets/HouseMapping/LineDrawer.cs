using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LineDrawer : MonoBehaviour
{
    private OSC osc;
    //private XRCustomController controller;

    [SerializeField] private InputActionProperty activateAction;

    [SerializeField] private LineRenderer lineVisual;
    [SerializeField] private Transform lineToolSocket;
    [SerializeField] private GameObject defaultLine = null;

    private Vector3 startPos;
    private Vector3 endPos;

    private bool _enabled = false;

    private void Start()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC));
        //controller = GetComponent<XRCustomController>();

        //assign methods for starting and finishing line upon hold start/end
        //controller.activateAction.action.performed += StartLine;
        //controller.activateAction.action.canceled += EndLine;

        activateAction.action.performed += StartLine;
        activateAction.action.canceled += EndLine;
    }

    private void StartLine(InputAction.CallbackContext obj)
    {
        ClearLine();

        Debug.Log("Line Started");
        

        startPos = lineToolSocket.position;

        _enabled = true;
        lineVisual.enabled = true;
    }

    private void ClearLine()
    {
        for (int i = 0; i < lineVisual.positionCount; i++)
        {
            lineVisual.SetPosition(i, Vector3.zero);
        }
    }

    private void EndLine(InputAction.CallbackContext obj)
    {
        endPos = lineToolSocket.position;

        SendLine(lineVisual);

        DuplicateLine(lineVisual);

        Debug.Log("Line Ended");

        _enabled = false;
        lineVisual.enabled = false;

        ClearLine();
    }

    private void DuplicateLine(LineRenderer line)
    {
        GameObject newLine = Instantiate(defaultLine);

        float posCount = line.positionCount;
        Vector3[] positions = new Vector3[(int)posCount];

        //get the old positions
        line.GetPositions(positions);

        //set the positions for the new line
        newLine.GetComponent<LineRenderer>().positionCount = (int)posCount;
        newLine.GetComponent<LineRenderer>().SetPositions(positions);
    }

    private void SendLine(LineRenderer line)
    {
        int pointCount = line.positionCount;

        //networking message
        OscMessage message = new OscMessage();
        
        message.address = "/newLine";
        message.values.Add(pointCount);

        for (int i = 0; i < pointCount; i++)
        {
            float x = line.GetPosition(i).x;
            float y = line.GetPosition(i).y;
            float z = line.GetPosition(i).z;

            message.values.Add(x);
            message.values.Add(y);
            message.values.Add(z);

            Debug.Log("POSITION SENT [" + i + "] : " + x + " | " + y + " | " + z);

        }
        
        osc.Send(message);
    }

    private void Update()
    {
        if (_enabled)
        {
            endPos = lineToolSocket.position;
            DrawLine(startPos, endPos);
        }
        
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        lineVisual.SetPosition(0, start);
        lineVisual.SetPosition(1, end);
    }
   
}
