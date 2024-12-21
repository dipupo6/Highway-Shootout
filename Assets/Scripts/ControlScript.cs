using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    private Camera cam;
    public GameObject myobject;
    private float speed = 20.0f;
    private Vector3 neutralPos = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        cam = Camera.main;        
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        neutralPos = new Vector3(0.0f, myobject.transform.position.y, myobject.transform.position.z);

        // If finger is on screen move to touch position
        if (Input.touchCount > 0)
        {
            Vector3 point = new Vector3();
            point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, myobject.transform.position.z - cam.transform.position.z));
            Vector3 targetPos = new Vector3(point.x, myobject.transform.position.y, myobject.transform.position.z);
            myobject.transform.position = Vector3.MoveTowards(myobject.transform.position, targetPos, step);
            //myobject.transform.position = new Vector3(point.x, myobject.transform.position.y, myobject.transform.position.z);
        }
        // If no finger on screen move to neutral position
        else
        {
            myobject.transform.position = Vector3.MoveTowards(myobject.transform.position, neutralPos, step);
        }
    }
}
