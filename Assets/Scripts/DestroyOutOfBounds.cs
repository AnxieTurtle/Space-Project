using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    private readonly float upBound = 25;
    private readonly float downBound = 15;
    private readonly float xRange = 30;

    void Update() {
        if(transform.position.z > upBound || transform.position.z < -downBound || transform.position.x < -xRange || transform.position.x > xRange)
            Destroy(gameObject);

    }
}
