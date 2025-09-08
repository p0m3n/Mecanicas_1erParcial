using UnityEngine;

public class Santi_Enemy : MonoBehaviour
{
     Rigidbody2D rb;
    public Transform target; // para ver si el core esta vivo y seguirlo
    public Transform player;// para disparar al jugador mientras avanza
    public Transform Santi; // Santi va ir al core pero le dispararar al jugador si esta cerca 
    public float speed = 3f;
    // si el core esta vivo
    public float health = 3f;
    private float timer;
    Vector2 dir; // direcione en la que va 
   // ya no lo use Vector2 aim;// direccion a donde apunte
    public float bss = 1.5f; //Bullet spawn speed 
    public AudioSource Deathsound;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Core").transform; // le puse core por que no se ciomo lo llamaremos en el juego
    }
    void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            dir = direction;
        }
       
        timer += Time.deltaTime;

        

    }
    void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(dir.x, dir.y) * speed; // para moverse a los lados pero hay que lockear el movement en y el los atributos 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))//para tomar dano 
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (health < 0) //para cuadno muera 
        {
            Destroy(Santi);
            AudioSource audioSource = Instantiate(Deathsound, transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(audioSource.gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer > bss)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bullet, player.position, Quaternion.identity);
    }

}
