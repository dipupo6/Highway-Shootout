using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CaptureScreenshot : MonoBehaviour
{

    public static int currentScreen;
    public virtual void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.CaptureScreen();
        }
    }

    public virtual void CaptureScreen()
    {
        ScreenCapture.CaptureScreenshot(("EditorScreenshots/Screenshots" + currentScreen++) + ".png", 4);
    }

}