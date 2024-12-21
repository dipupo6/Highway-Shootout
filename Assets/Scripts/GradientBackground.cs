using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GradientBackground : MonoBehaviour
{
    public Color topColor;
    public Color bottomColor;
    public int gradientLayer;
    public Shader shader;
    public virtual void Awake()
    {
        this.gradientLayer = Mathf.Clamp(this.gradientLayer, 0, 31);
        if (!this.GetComponent<Camera>())
        {
            Debug.LogError("Must attach GradientBackground script to the camera");
            return;
        }
        this.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        this.GetComponent<Camera>().cullingMask = this.GetComponent<Camera>().cullingMask & ~(1 << this.gradientLayer);
        Camera gradientCam = new GameObject("Gradient Cam", new System.Type[] {typeof(Camera)}).GetComponent<Camera>();
        gradientCam.depth = this.GetComponent<Camera>().depth - 1;
        gradientCam.cullingMask = 1 << this.gradientLayer;
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {new Vector3(-100, 0.577f, 1), new Vector3(100, 0.577f, 1), new Vector3(-100, -0.577f, 1), new Vector3(100, -0.577f, 1)};
        mesh.colors = new Color[] {this.topColor, this.topColor, this.bottomColor, this.bottomColor};
        mesh.triangles = new int[] {0, 1, 2, 1, 3, 2};
        //	var mat = new Material("Shader \"Vertex Color Only\"{Subshader{BindChannels{Bind \"vertex\", vertex Bind \"color\", color}Pass{}}}");
        Material mat = new Material(this.shader);
        GameObject gradientPlane = new GameObject("Gradient Plane", new System.Type[] {typeof(MeshFilter), typeof(MeshRenderer)});
        (((MeshFilter) gradientPlane.GetComponent(typeof(MeshFilter))) as MeshFilter).mesh = mesh;
        gradientPlane.GetComponent<Renderer>().material = mat;
        gradientPlane.layer = this.gradientLayer;
    }

    public GradientBackground()
    {
        this.topColor = Color.blue;
        this.bottomColor = Color.white;
        this.gradientLayer = 7;

        
    }


}