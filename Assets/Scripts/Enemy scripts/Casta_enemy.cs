using UnityEngine;

public class Casta_enemy : MonoBehaviour
{
  Rigidbody2D rb;
    public Transform target; // para ver si el core esta vivo y seguirlo
    public Transform Casta; //catsa va a rushear el core 
    public float speed = 6f;
    // si el core esta vivo
    public float health = 2f;
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
            Destroy(Casta);
            AudioSource audioSource = Instantiate(Deathsound, transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(audioSource.gameObject);

        }
    }
    
}
