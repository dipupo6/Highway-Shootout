using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDis : MonoBehaviour
{
    public int destroyTime = 5;
    public GameObject InitSpawner;
    public GameObject HardSpawner;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(WaitThenDie());
    }
     IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(destroyTime);
        HardSpawner.GetComponent<ExtrasSpawner>().enabled = true;
        InitSpawner.GetComponent<HardSpawner>().enabled = false;
    }
}
