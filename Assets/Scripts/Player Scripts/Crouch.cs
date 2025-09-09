using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Crouch : Player
{
    public float raycastDistance_hit_roof = 0.38f;
    private bool noRoof;
    public Vector2 sizeBoxToRoof = new Vector2(0.78f, 0.76f);
    public Interactuar_Objeto interactuarObjeto;
    public Horizontal_Movement horizontal;
    private Jump jump;
    public LayerMask floorLayer;

    private Vector2 initialColliderSize;
    private Vector2 initialColliderOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Features();
        horizontal = GetComponent<Horizontal_Movement>();
        jump = GetComponent<Jump>();

        if (bc != null)
        {
            initialColliderSize = bc.size;
            initialColliderOffset = bc.offset;
        }

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit_roof = Physics2D.BoxCast(transform.position, sizeBoxToRoof, 0f, Vector2.up, raycastDistance_hit_roof, floorLayer);
        noRoof = hit_roof.collider == null;

        // Agacharse
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && jump.onFloor)
        {
            isCrouching = true;
            interactuarObjeto.AgarrarSoltar();

            // El tamaño Y es la mitad del original
            bc.size = new Vector2(initialColliderSize.x, initialColliderSize.y * 0.5f);
            // El offset Y se ajusta para que el collider se encoja hacia abajo
            bc.offset = new Vector2(initialColliderOffset.x, initialColliderOffset.y - (initialColliderSize.y * 0.25f));

            horizontal.velocity = 3f;
            jump.jumpForce = 3f;
        }
        else
        {
            if (noRoof)
            {
                isCrouching = false;
                interactuarObjeto.Arrojar();

                // --> 4. Restauramos el tamaño y offset a sus valores originales
                bc.size = initialColliderSize;
                bc.offset = initialColliderOffset;

                horizontal.velocity = 7f;
                jump.jumpForce = 7f;
            }
        }

        anim.SetBool("Crouching", isCrouching);

    }

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;

        Vector2 endPos_hit_roof = origin + Vector2.up * raycastDistance_hit_roof;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(endPos_hit_roof, sizeBoxToRoof);
    }
}
