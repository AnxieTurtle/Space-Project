using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward: MonoBehaviour {
    public float forwardSpeed = 1f;

    void Update() {
        transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward * SpawnManager.speedGlobal);
    }
}
