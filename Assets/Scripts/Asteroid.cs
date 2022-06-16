using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid:DestroyableObject {
    [SerializeField] private GameObject smallAsteroidPrefab;
    private int countSmallAsteroid = 3;

    //public int health = 1;
    //public float speed = 1f;
    //public GameObject asteroidPrefab;
    //public ParticleSystem explosion;

    private void OnTriggerEnter(Collider other) {
        CheckCollider(other);
    }

    protected override void CheckCollider(Collider other) {
        base.CheckCollider(other);
        if(other.gameObject.CompareTag("Enemy Bullet") || other.gameObject.CompareTag("Asteroid Small")) {
            health -= 1;
            Destroy(other.gameObject);
            CheckHealth();
        }
    }
    protected override void CheckHealth() {
        base.CheckHealth();
        if(health <= 0) {
            for(int i = 0; i < countSmallAsteroid; i++) {
                Instantiate(smallAsteroidPrefab, transform.position + RandomPosition(), smallAsteroidPrefab.transform.rotation);
            }
        }
    }

    private Vector3 RandomPosition() {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
        return randomPosition;
    }
    //private void OnTriggerEnter(Collider other) {
    //    if(other.gameObject.CompareTag("Player Bullet") || other.gameObject.CompareTag("Enemy Bullet") || other.gameObject.CompareTag("Asteroid Small")) {
    //        health -= 1;
    //        Destroy(other.gameObject);
    //        CheckHealth();
    //    } else if(other.gameObject.CompareTag("Player")) {
    //        health = 0;
    //        CheckHealth();
    //    }
    //}
    //void CheckHealth() {
    //    if(health <= 0) {
    //        Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);
    //        Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);
    //        Instantiate(asteroidPrefab, transform.position + RandomPosition(), asteroidPrefab.transform.rotation);

    //        Instantiate(explosion, transform.position, explosion.transform.rotation);
    //        Destroy(gameObject);
    //    }
    //}

}
