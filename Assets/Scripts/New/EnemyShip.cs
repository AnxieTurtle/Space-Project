using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyShip:DestroyableObject {
    [SerializeField] private GameObject bulletPrefab;
    private GameObject player;

    private float bulletOffset = 1f;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");

        float randRepeatFire = Random.Range(0.5f, 2f);
        InvokeRepeating(nameof(Fire), 1, randRepeatFire);
    }
    private void Update() {
        Move();
    }
    private void OnTriggerEnter(Collider other) {
        CheckCollider(other);
    }

    // POLYMORPHISM
    protected override void CheckCollider(Collider other) {
        base.CheckCollider(other);
        if (other.gameObject.CompareTag("Asteroid Small")) {
            health -= 1;
            Destroy(other.gameObject);
            CheckHealth();
        }
    }

    void Fire() {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + -bulletOffset);
        GameObject obj = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        obj.transform.LookAt(player.transform);
    }
    void Move() {
        transform.Translate(Speed * Time.deltaTime * Vector3.forward * SpawnManager.speedGlobal);
    }
}
