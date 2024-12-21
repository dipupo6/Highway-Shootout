using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    private Music music;
    public Button musicToggleButton;
    public Sprite audioOn;
    public Sprite audioOff; 
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIconAndVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseMusic(){
        music.ToggleSound();
        UpdateIconAndVolume();
    }

    void UpdateIconAndVolume(){
        if (PlayerPrefs.GetInt("Muted", 0) == 0){
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = audioOn;
        }
        else{
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = audioOff;
        }
    }
}
