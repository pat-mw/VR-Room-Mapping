using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothLineDrawer : MonoBehaviour
{
    private OSC osc;

    [SerializeField] private InputActionProperty selectAction;

    [SerializeField] private LineRenderer smoothLineVisual;
    [SerializeField] private Transform lineToolSocket;
    [SerializeField] private GameObject defaultLine = null;
    [SerializeField] private float waitTime = 0.5f;

    private List<Vector3> positionsList;

    private bool _enabled = false;

    private void Start()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC));

        positionsList = new List<Vector3>();

        //assign methods for starting and finishing line upon hold start/end
        selectAction.action.performed += StartLine;
        selectAction.action.canceled += EndLine;
    }

    private void StartLine(InputAction.CallbackContext obj)
    {
        _enabled = true;
        smoothLineVisual.enabled = true;

        StartCoroutine("LineUpdate", waitTime);

        Debug.Log("Line Started");
    }

    IEnumerator LineUpdate(float waitTime)
    {
        //if currently enabled
        while (_enabled)
        {
            // add new point and display the line again
            positionsList.Add(lineToolSocket.position);
            DrawNewPoint(smoothLineVisual);

            // default delay
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void ClearLine(LineRenderer line)
    {
        //clear the given line
        line.positionCount = 1;
        line.SetPosition(0, lineToolSocket.position);


        //reset the position list
        positionsList.Clear();
    }

    private void EndLine(InputAction.CallbackContext obj)
    {
        CancelInvoke();

        // send the line over network to PC receiver (for mapping)
        SendLine(smoothLineVisual);

        // duplicate the local instance of the line for local representation
        DuplicateLine(smoothLineVisual);

        // disable the line visual
        _enabled = false;
        smoothLineVisual.enabled = false;

        // clear the line visual
        ClearLine(smoothLineVisual);


        Debug.Log("Line Ended");
    }

    //duplicate the given line in world space for visual map on device
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

    //send the given line via network to PC client
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

    private void DrawNewPoint(LineRenderer line)
    {
        int pointCount = positionsList.Count;
        line.positionCount = pointCount;
        line.SetPosition(pointCount-1, positionsList[pointCount-1]);


        Debug.Log("New Point Added");

    }

}