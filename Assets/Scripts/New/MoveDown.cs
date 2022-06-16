using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown: MonoBehaviour {
    private float moveDownSpeed = 1f;

    void Update() {
        transform.Translate(moveDownSpeed * Time.deltaTime * Vector3.forward * SpawnManager.speedGlobal);
    }
}
