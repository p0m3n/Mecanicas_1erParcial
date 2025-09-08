using UnityEngine;

public class Bullet_behaiviour : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 dir;
    public float speed = 5f;
    private float timer;
    public float bulletdistance = 7f;
    void Start()
    {
        GetComponent<Rigidbody2D>();
        if (player)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            dir = direction;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bulletdistance)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(dir.x, dir.y) * speed; // para moverse a los lados pero hay que lockear el movement en y el los atributos 
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
