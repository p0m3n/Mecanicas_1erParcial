using UnityEngine;

public class Horizontal_Movement : MonoBehaviour // Asegúrate que no herede de Player
{
    public float velocity = 5f;
    private Vector2 movement;

    // Referencias a otros componentes
    private Rigidbody2D rb;
    private Animator anim;
    private Player player; // La referencia al "cerebro"
    private Crouch crouch;

    void Awake()
    {
        // Obtenemos todos los componentes necesarios
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        crouch = GetComponent<Crouch>();
    }

    void Update()
    {
        // Leer la entrada del teclado
        if (player != null && !player.grabbingLedge)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            movement.x = 0; // Si estamos en un borde, no nos movemos
        }

        // Llamamos a la función que actualiza las animaciones
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        // Aplicamos el movimiento físico
        rb.linearVelocity = new Vector2(movement.x * velocity, rb.linearVelocity.y);

        // La decisión de girar también debe estar en FixedUpdate para estar sincronizada con la física
        HandleFlip();
    }

    void HandleFlip()
    {
        // Si nos movemos a la izquierda (input < 0) Y NO estamos mirando a la izquierda...
        if (movement.x < 0 && !player.isFacingLeft)
        {
            player.Flip(); // ...le damos la orden de girar.
        }
        // O si nos movemos a la derecha (input > 0) Y SÍ estamos mirando a la izquierda...
        else if (movement.x > 0 && player.isFacingLeft)
        {
            player.Flip(); // ...le damos la orden de girar.
        }
    }

    void UpdateAnimations()
    {
        if (movement.x != 0)
        {
            // Estamos en movimiento
            anim.SetBool("Idle", false);

            if (crouch != null && crouch.isCrouching)
            {
                anim.SetBool("moveCrouching", true);
                anim.SetBool("Walking", false);
            }
            else
            {
                anim.SetBool("Walking", true);
                anim.SetBool("moveCrouching", false);
            }
        }
        else
        {
            // Estamos quietos
            anim.SetBool("Idle", true);
            anim.SetBool("Walking", false);
            anim.SetBool("moveCrouching", false);
        }
    }
}