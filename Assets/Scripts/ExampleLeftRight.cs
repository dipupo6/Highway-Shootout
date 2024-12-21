using UnityEngine;
using System.Collections;

public partial class ExampleLeftRight : MonoBehaviour
{
    public bool KeyboardControl;

    public GameObject Cube;

    Transform CubeTransform;
    void Awake()
    {
        CubeTransform = Cube.transform;
    }

    private void Update()
    {
        if (KeyboardControl == true)
        {
            // If no input KeyboardControl
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                CubeTransform.rotation = Quaternion.Lerp(CubeTransform.rotation, Quaternion.Euler(0, 0, 0), 20 * Time.fixedDeltaTime);
            }
        }

        if (KeyboardControl == false)
        {
            // If no touch rotate back to neutral position
            if (Input.touchCount == 0 || Input.touchCount > 1)
            {
                CubeTransform.rotation = Quaternion.Lerp(CubeTransform.rotation, Quaternion.Euler(0, 0, 0), 20 * Time.fixedDeltaTime);
            }
        }
    }

    public virtual void FixedUpdate()
    {

        var myEuler = CubeTransform.eulerAngles;
        var myPos = CubeTransform.position;

        //// Keyboard control ////
        if (this.KeyboardControl == true)
        {
            // Left
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if(transform.position.x >= -2.77f)
                {
                    // Go left
                    myPos.x -= 0.3f;
                    myEuler += new Vector3(0, 0, 1.0f) * 30 * Time.fixedDeltaTime;
                    if (myEuler.z >= 10 && myEuler.z < 350)
                    {
                        myEuler = new Vector3(0, 0, 10);
                    }
                } else 
                {
                   Vector3 newPosition = new Vector3(-8.5f, transform.position.y, transform.position.z);
                   transform.position = newPosition;
                }    
            }
            // Right
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if(transform.position.x <= 2.77f)
                {
                    // Go right
                    myPos.x += 0.3f;
                    myEuler -= new Vector3(0, 0, 1.0f) * 30 * Time.fixedDeltaTime;
                    if (myEuler.z <= 350 && myEuler.z > 10)
                    {
                        myEuler = new Vector3(0, 0, 350);
                    }
                } else 
                {
                   Vector3 newPosition = new Vector3(2.77f, transform.position.y, transform.position.z);
                   transform.position = newPosition;
                }    
            }
            // If no input
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                // Do nothing
                // Look in Update function
            }
        }

        //// Touch control ////
        if (this.KeyboardControl == false)
        {
            // Left
            if ((Input.touchCount == 1) && (Input.GetTouch(0).position.x < (Screen.width / 2)))
            {
                if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject) return;
                if(transform.position.x >= -2.77f)
                {
                    // Go left
                    myPos.x -= 0.3f;
                    myEuler += new Vector3(0, 0, 1.0f) * 30 * Time.fixedDeltaTime;
                    if (myEuler.z >= 10 && myEuler.z < 350)
                    {
                        myEuler = new Vector3(0, 0, 10);
                    }
                } else 
                {
                   Vector3 newPosition = new Vector3(-2.77f, transform.position.y, transform.position.z);
                   transform.position = newPosition;
                }  
            }
            // Right
            if ((Input.touchCount == 1) && (Input.GetTouch(0).position.x > (Screen.width / 2)))
            {
                if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject) return;
                if(transform.position.x <= 2.77f)
                {
                    // Go right
                    myPos.x += 0.3f;
                    myEuler -= new Vector3(0, 0, 1.0f) * 30 * Time.fixedDeltaTime;
                    if (myEuler.z <= 350 && myEuler.z > 10)
                    {
                        myEuler = new Vector3(0, 0, 350);
                    }
                } else 
                {
                   Vector3 newPosition = new Vector3(2.77f, transform.position.y, transform.position.z);
                   transform.position = newPosition;
                }   
            }
            // If no input
            if ((Input.touchCount == 0) || (Input.touchCount > 1))
            {
                // Do nothing
                // Look in Update function
            }
        }

        // Reassign the temporal buffers that we use to limit the overhead

        CubeTransform.position = myPos;
        CubeTransform.eulerAngles = myEuler;
    }
}