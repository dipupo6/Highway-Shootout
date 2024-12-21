using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class PauseMenu1 : MonoBehaviour
{
   public GameObject Player;
   public GameObject PauseButton; 
   public GameObject ResumeButton;

   public void Pause(){
       ResumeButton.SetActive(true);
       PauseButton.SetActive(false);
       Time.timeScale = 0;
       Player.GetComponent<PlayerController>().enabled = false;
       Debug.Log("Paused");
   }

    public void Resume(){
       ResumeButton.SetActive(false);
       PauseButton.SetActive(true);
       Time.timeScale = 1; 
       Player.GetComponent<PlayerController>().enabled = true;
   }


}
