using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColor : MonoBehaviour
{
    public Material sr;
	public Color desert;
	public Color winter;
    public Color winterIce;
	public Color rocky;
	public string currentColor;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
                currentColor = "Desert";
				sr.color = desert;
				break;
			case 1:
			    currentColor = "Winter";
				sr.color = winter;
				break;
            case 2:
			    currentColor = "WinterIce";
				sr.color = winterIce;
				break; 
		    case 3:
			    currentColor = "Rocky";
				sr.color = rocky;
				break; 			 
		}
	}
}
