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

    /// <summary>
    /// Se ejecuta cuando la bala entra en el collider de otro objeto.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        // ✅ LÓGICA AÑADIDA
        // Comprueba si el objeto con el que chocó tiene la etiqueta "Enemy".
        if (other.CompareTag("Enemy"))
        {
            // Si es un enemigo, destruye el objeto del enemigo.
            Destroy(other.gameObject);
        }

        // Finalmente, la bala se destruye a sí misma al chocar con cualquier cosa.
        Destroy(gameObject);
    }
}