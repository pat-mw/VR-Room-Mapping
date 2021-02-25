using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointReceiver : MonoBehaviour
{
    OSC osc;        //reference to the osc script that will receive the network messages
    Transform map;  //a holder for the points

    [SerializeField] private string messageKey = "/newPoint";
    [SerializeField] private string mapName = "Generated Map";


    [SerializeField] GameObject m_prefab = null;
    void Start()
    {
        //open the OSC and set it to listen to messages with the given Key
        osc = (OSC)FindObjectOfType(typeof(OSC)); 
        osc.SetAddressHandler(messageKey, OnReceivePoint); 

        //if no map exists, create one, and then rename the map
        if (GameObject.Find("Map") == null)
            map = new GameObject().transform;
        map.gameObject.name = mapName; 
    }

    void OnReceivePoint(OscMessage message)
    {        
        float x = message.GetFloat(0);
        float y = message.GetFloat(1);
        float z = message.GetFloat(2);

        Debug.Log("---------------");
        Debug.Log("received point" );
        Debug.Log("x: " + x + " | y: " + y + " | z: " + z);

        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cube
        //cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); //scale it down
        //cube.transform.position = new Vector3(x, y, z); //place it at the position received
        //cube.transform.parent = map; //parent it to the 'Generated Map' object


        //create a new prefab and position it where the controller is
        GameObject prefab = Instantiate(m_prefab);
        prefab.transform.position = new Vector3(x, y, z);
        prefab.transform.parent = map;
    }

}