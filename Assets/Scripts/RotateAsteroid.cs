using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAsteroid : MonoBehaviour {

    private float rotationSpeed;
    private Vector3 rotation;

    private void Start() {
        if(gameObject.CompareTag("Asteroid Small")) {
            rotationSpeed = Random.Range(80f, 120f);
        } else {
            rotationSpeed = Random.Range(30f, 60f);
        }
        
        transform.rotation = Quaternion.Euler(StartRotation(), StartRotation(), StartRotation());
        rotation = new Vector3(VectorRotation(), VectorRotation(), VectorRotation());
    }

    void Update() {
        transform.Rotate(rotationSpeed * Time.deltaTime * rotation);
    }

    float VectorRotation() {
        return Random.Range(0.1f, 1f);
    }
    float StartRotation() {
        return Random.Range(0, 180);
    }
}
