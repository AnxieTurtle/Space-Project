using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmall : MonoBehaviour {
    public int health = 1;
    public float speed = 5f;
    private Vector3 randomVector3;

    private void Start() {
        float randomX = Random.Range(-1f,1f);
        float randomZ = Random.Range(0f, 1f);
        randomVector3 = new Vector3(randomX, 0, randomZ);
    }

    void Update() {
        transform.Translate(speed * Time.deltaTime * randomVector3);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player Bullet")) {
            health -= 1;
            Destroy(other.gameObject);
            CheckHealth();
        } else if(other.gameObject.CompareTag("Player")) {
            health = 0;
            CheckHealth();
        }
    }
    void CheckHealth() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
