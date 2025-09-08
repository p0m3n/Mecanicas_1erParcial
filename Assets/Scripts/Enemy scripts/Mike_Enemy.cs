using UnityEngine;

public class Mike_Enemy : MonoBehaviour
{
Rigidbody2D rb;
    public Transform target; // para ver si el core esta vivo y seguirlo
    public Transform Mike; // voy por el jugador 
    public float speed = 4f;
    // si el core esta vivo
    public float health = 3f;
    Vector2 dir; // direcione en la que va 
    public AudioSource Deathsound;

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

    }
    void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(dir.x, dir.y)*speed; // para moverse a los lados pero hay que lockear el movement en y el los atributos 
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
            Destroy(Mike);
            AudioSource audioSource = Instantiate(Deathsound, transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(audioSource.gameObject);

        }
    }
    
 
}
