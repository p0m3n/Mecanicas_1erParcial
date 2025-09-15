using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Retraso de Disparo (Cooldown)")]
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    // Referencia al script Player para saber su estado
    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        // La condición para disparar sigue igual
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            if (player != null && !player.grabbingLedge)
            {
                nextFireTime = Time.time + fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // --- LÓGICA DE DIRECCIÓN CORREGIDA Y FORZADA ---

        // 1. Creamos un vector de dirección vacío.
        Vector2 shotDirection;

        // 2. Decidimos la dirección basándonos en el booleano 'isFacingLeft' del Player.
        if (player.isFacingLeft)
        {
            shotDirection = Vector2.left; // Dirección (-1, 0)
        }
        else
        {
            shotDirection = Vector2.right; // Dirección (1, 0)
        }

        // 3. Creamos la bala (la rotación ya no es tan importante, pero la dejamos por si el sprite la necesita)
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullets bulletScript = bullet.GetComponent<Bullets>();

        // 4. Le pasamos a la bala la dirección que acabamos de calcular manualmente.
        if (bulletScript != null)
        {
            bulletScript.SetDirection(shotDirection);
        }
    }
}