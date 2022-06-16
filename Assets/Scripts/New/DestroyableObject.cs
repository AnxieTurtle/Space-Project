using UnityEngine;

public class DestroyableObject:MonoBehaviour {
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] protected int health = 1;
    [SerializeField] private float speed = 3f;
    protected float Speed { get { return speed; } }
    [SerializeField] private bool isHealthDrop = false;

    protected virtual void Kill() {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
        Drop(healthPrefab);
    }
    protected virtual void CheckCollider(Collider other) {
        if(other.gameObject.CompareTag("Player Bullet")) {
            health -= 1;
            Destroy(other.gameObject);
            CheckHealth();
        } else if(other.gameObject.CompareTag("Player")) {
            health = 0;
            CheckHealth();
        }
    }
    // ABSTRACTION
    protected virtual void CheckHealth() {
        if(health <= 0) Kill();
    }
    void Drop(GameObject prefab) {
        if(isHealthDrop)
            Instantiate(prefab, gameObject.transform.position, prefab.transform.rotation);
    }
}
