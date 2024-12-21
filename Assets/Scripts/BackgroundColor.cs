using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    private GameObject GradientPlane;
    private Color[] colorArray = { Color.black, Color.black, Color.black, Color.black };
    // Start is called before the first frame update
    void Start()
    {
        GradientPlane = GameObject.Find("Gradient Plane");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.score > 10)
        {
            FirstColor();
        }

        if (Score.score > 20)
        {
            SecondColor();
        }

        if (Score.score > 40)
        {
            ThirdColor();
        }

        if (Score.score > 60)
        {
            FourthColor();
        }
    }

    public void FirstColor()
    {
        // first two colors in array for top and second two for bottom color
        Color[] colorArray = { Color.cyan, Color.cyan, Color.white, Color.white };
        GradientPlane.GetComponent<MeshFilter>().mesh.colors = colorArray;
    }

    public void SecondColor()
    {
        // first two colors in array for top and second two for bottom color
        Color[] colorArray = { Color.black, Color.black, Color.green, Color.green };
        GradientPlane.GetComponent<MeshFilter>().mesh.colors = colorArray;
    }

    public void ThirdColor()
    {
        // first two colors in array for top and second two for bottom color
        Color[] colorArray = { Color.red, Color.red, Color.yellow, Color.yellow };
        GradientPlane.GetComponent<MeshFilter>().mesh.colors = colorArray;
    }

    public void FourthColor()
    {
        // first two colors in array for top and second two for bottom color
        Color[] colorArray = { Color.black, Color.black, Color.yellow, Color.yellow };
        GradientPlane.GetComponent<MeshFilter>().mesh.colors = colorArray;
    }

    public void EndColor()
    {
        // first two colors in array for top and second two for bottom color
        Color[] colorArray = { Color.black, Color.black, Color.black, Color.black };
        GradientPlane.GetComponent<MeshFilter>().mesh.colors = colorArray;
    }
}
