using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    // The Target
    public Transform target;
    float spawnPos = 5f;

    void LateUpdate () {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         target.position.z - spawnPos);
    }
}
