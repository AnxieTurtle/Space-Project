using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int health = 1;
    public float speed = 20f;
    public float xBound = 17f, zBoundUp = 15f, zBoundDown = -6.5f;

    public GameObject bulletPrefab;

    void Update() {
        MovePlayer();
        ConstrainPlayerPosition();
        Fire();
    }

    void MovePlayer() {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new(horizontalInput, 0, verticalInput);
        //двигать игрока вперЄд назад влево вправо
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    void ConstrainPlayerPosition() {
        //Horizontal bounds
        if(transform.position.x < -xBound) {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        } else if(transform.position.x > xBound) {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        //Vertical bounds
        if(transform.position.z < zBoundDown) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundDown);
        } else if(transform.position.z > zBoundUp) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundUp);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //Destroy(other.gameObject);
        if(other.CompareTag("Health")) {
            Destroy(other.gameObject);
            health += 1;
            Debug.Log("+ здоровье!");
        } else if(other.CompareTag("Enemy") || other.CompareTag("Asteroid")) {
            health -= 1;
            Debug.Log("- здоровье!");
            CheckHealth();
        } else if(other.CompareTag("Enemy Bullet")) {
            health -= 1;
            Debug.Log("- здоровье!");
            Destroy(other.gameObject);
            CheckHealth();
        }

    }
    void CheckHealth() {
        if(health <= 0) {
            Debug.Log(" онец игры!");
        }
    }

    void Fire() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector3 position = new(transform.position.x, transform.position.y, transform.position.z + 1);
            Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        }
    }
}
