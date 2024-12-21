using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenuButton : MonoBehaviour
{
    private Button mainmenuButton;
    // Start is called before the first frame update
    void Start()
    {
        mainmenuButton = GetComponent<Button>();
        mainmenuButton.onClick.AddListener(MainGame);
    }

    // Update is called once per frame
    private void MainGame()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        
    }
}