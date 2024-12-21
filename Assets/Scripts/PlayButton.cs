using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    private void PlayGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
