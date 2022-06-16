using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public int health = 1;
    public float speed = 1f;
    public GameObject asteroidPrefab;
    public ParticleSystem explosion;

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player Bullet") || other.gameObject.CompareTag("Enemy Bullet") || other.gameObject.CompareTag("Asteroid Small")) {
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
            Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);
            Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);
            Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);

            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
    Vector3 RandomPosition() {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
        return randomPosition;
    }
}
