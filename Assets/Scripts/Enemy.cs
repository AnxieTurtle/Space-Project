using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject healthPrefab;
    private GameObject player;
    public ParticleSystem explosion;
    private float bulletOffset = 1f;
    private Vector3 startPosition; // стартовая позиция корабля

    public int health = 1;
    public float speed = 8f;
    public bool isDropHealth = false;

    //public bool onFire = true; //влючение стрельбы
    public int fireMode; //тип стрельбы             стреляет вниз, по игроку,
    public int moveMode; //тип движения


    private void Start() {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        FireMode(fireMode);
    }
    void FireMode(int fireMode) {
        float randStart = Random.Range(1f, 2f);
        float randRepeat = Random.Range(1f, 2f);
        switch(fireMode) {
            case 1:
                InvokeRepeating(nameof(Fire1), randStart, randRepeat);
                break;
            case 2:
                InvokeRepeating(nameof(Fire2), randStart, randRepeat);
                break;
        }
    }
    void Fire1() {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + -bulletOffset);
        Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
    }
    void Fire2() {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + -bulletOffset);
        GameObject obj = Instantiate(bulletPrefab, position, bulletPrefab.transform.rotation);
        obj.transform.LookAt(player.transform);
        //Enemy enemy = obj.GetComponent<Enemy>();
        //enemy.fireMode = 1;

        //сделать новые префабы пуль
        //  летит в позицию игрока в момент спавна пули
        //  летит в игрока с самонаводкой
    }

    private void Update() {
        MoveEnemy(moveMode);
    }
    void MoveEnemy(int moveMode) {
        switch(moveMode) {
            case 1:
                transform.Translate(speed * Time.deltaTime * Vector3.forward * SpawnManager.speedGlobal);
                break;
            case 2:
                if(startPosition.x <= 0) {
                    transform.Translate(speed * Time.deltaTime * Vector3.left * SpawnManager.speedGlobal);
                } else {
                    transform.Translate(speed * Time.deltaTime * Vector3.right * SpawnManager.speedGlobal);
                }
                break;
        }

        //if(moveEnemy == 1) {
        //    //просто летит вниз (ускоренно)
        //    transform.Translate(speed * Time.deltaTime * Vector3.forward);
        //} else if(moveEnemy == 2) {
        //    if(startPosition.x <= 0) {
        //        transform.Translate(speed * Time.deltaTime * Vector3.left);
        //    } else {
        //        transform.Translate(speed * Time.deltaTime * Vector3.right);
        //    }
        //}
    }



    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player Bullet") || other.gameObject.CompareTag("Asteroid Small")) {
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
            if(isDropHealth)
                Instantiate(healthPrefab, gameObject.transform.position, healthPrefab.transform.rotation);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
}
