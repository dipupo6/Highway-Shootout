using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    void Start(){
    }
    // Start is called before the first frame update
    void Update()
    {
       if (Application.platform == RuntimePlatform.Android){
           if (Input.GetKeyDown(KeyCode.Escape)){
               Application.Quit();
               return;
            }
       } 
    }
}
