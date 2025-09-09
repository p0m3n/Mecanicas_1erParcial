using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    protected Animator anim;

    protected Player player;

    [HideInInspector]
    public bool isFacingLeft = false;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;
    [HideInInspector]
    public bool isCrouching;
    [HideInInspector]
    public bool grabbingLedge;
    [HideInInspector]
    public bool takingDamage;
    [HideInInspector]
    public bool isDead;

    public Vector2 FacingDirection
    {
        get { return isFacingLeft ? Vector2.left : Vector2.right; }
    }



    Vector2 facingLeft;


    private void Awake()
    {
        Features();
    }

    protected virtual void Features()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    public void Flip()
    {
        // Invierte el estado
        isFacingLeft = !isFacingLeft;

        // Invierte la escala del objeto para girarlo visualmente
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        // ¡PRUEBA CRÍTICA! Este mensaje nos dirá si la función se está ejecutando.
        Debug.Log("¡FLIP EJECUTADO! Nuevo estado isFacingLeft = " + isFacingLeft);
    }

}
