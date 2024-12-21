using System.Collections;
using UnityEngine;

public class BendController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleBendAmount());
    }



    public IEnumerator ToggleBendAmount()
    {
        bool toggled = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.0f, 8.0f));

        while (true)
        {

            if (BendScript.Instance.bendAmount_Y <= 0 && toggled)
            {
                BendScript.Instance.bendAmount_Y += Time.deltaTime / 10;
                BendScript.Instance.bendAmount_X -= Time.deltaTime / 10;

                if (BendScript.Instance.bendAmount_Y >= 0)
                {
                    toggled = false;
                    yield return new WaitForSeconds(UnityEngine.Random.Range(5.0f, 8.0f));
                }
            }

            else if (BendScript.Instance.bendAmount_X <= 0 && !toggled)
            {
                BendScript.Instance.bendAmount_X += Time.deltaTime / 10;
                BendScript.Instance.bendAmount_Y -= Time.deltaTime / 10;

                if (BendScript.Instance.bendAmount_X >= 0)
                {
                    toggled = true;
                    yield return new WaitForSeconds(UnityEngine.Random.Range(0.0f, 8.0f));
                }
            }

            yield return new WaitForSeconds(1.0001f);
        }
    }
}
