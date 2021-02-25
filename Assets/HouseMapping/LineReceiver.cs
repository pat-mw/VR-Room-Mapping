
using System.Collections.Generic;
using UnityEngine;

public class LineReceiver : MonoBehaviour
{
    OSC osc;        //reference to the osc script that will receive the network messages
    Transform map;  //a holder for the points

    [SerializeField] private string messageKey = "/newLine";
    [SerializeField] private string mapName = "Generated Map";


    [SerializeField] GameObject linePrefab = null;
    void Start()
    {
        //open the OSC and set it to listen to messages with the given Key
        osc = (OSC)FindObjectOfType(typeof(OSC));
        osc.SetAddressHandler(messageKey, OnReceiveLine);

        //if no map exists, create one, and then rename the map
        if (GameObject.Find("Map") == null)
            map = new GameObject().transform;
        map.gameObject.name = mapName;
    }

    void OnReceiveLine(OscMessage message)
    {
        float pointCount = message.GetInt(0);
        float dataCount = pointCount * 3;

        //List<Vector3> positions = new List<Vector3>();

        Vector3[] positions = new Vector3[(int)pointCount];

        for (int i = 1; i <= dataCount; i += 3 )
        {
            int positionIndex = i / 3;

            float x = message.GetFloat(i);
            float y = message.GetFloat(i + 1);
            float z = message.GetFloat(i + 2);

            //Debug.Log("POSITION RECEIVED [" + positionIndex + "] : " + x + " | " + y + " | " + z);

            positions[positionIndex] = new Vector3(x, y, z);
        }


        //float x1 = message.GetFloat(0);
        //float y1 = message.GetFloat(1);
        //float z1 = message.GetFloat(2);
        //float x2 = message.GetFloat(3);
        //float y2 = message.GetFloat(4);
        //float z2 = message.GetFloat(5);


        Debug.Log("---------------");
        Debug.Log("received line");
        Debug.Log("START -- : " + positions[0]);
        Debug.Log("END -- : " + positions[(int)pointCount -1]);


        //create a new prefab and position it where the controller is
        GameObject line = Instantiate(linePrefab);
        //line.transform.position = positions[0];

        var lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = (int)pointCount;
        lineRenderer.SetPositions(positions);



        line.transform.parent = map;
    }

}