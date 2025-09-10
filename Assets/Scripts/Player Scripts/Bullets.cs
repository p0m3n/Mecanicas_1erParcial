// EN EL SCRIPT DE LA BALA (EJ: Bullets.cs)
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector2 direction)
    {
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Puedes añadir aquí tu lógica de colisión (ej: con enemigos)
        Destroy(gameObject);
    }
}