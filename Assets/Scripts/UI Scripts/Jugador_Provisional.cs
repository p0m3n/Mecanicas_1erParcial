using UnityEngine;
using UnityEngine.UI;

public class Jugador_Provisional : MonoBehaviour
{
    public float speed = 10;
    public float force = 5f;
    public int vidas = 3;
    public Rigidbody2D rigidbody2D;
    public Image[] vidasHUD;
    public CanvasGroup panelDerrotaCanvasGroup;
    private Vector3 direction = Vector2.right;
    public bool alive = true;

    void Start()
    {
        ActualizarHUD();
        if (panelDerrotaCanvasGroup != null)
        {
            panelDerrotaCanvasGroup.alpha = 0f;
            panelDerrotaCanvasGroup.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("El panel de derrota no ha sido asignado en el Inspector del Jugador.");
        }
    }

    void PerderVida()
    {
        if (!alive) return;

        vidas--;
        Debug.Log("Vidas restantes: " + vidas);

        ActualizarHUD();

        if (vidas <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        alive = false;
        MostrarPanelDerrota();

        gameObject.SetActive(false);
    }

    void MostrarPanelDerrota()
    {
        if (panelDerrotaCanvasGroup != null)
        {
            panelDerrotaCanvasGroup.gameObject.SetActive(true);
            panelDerrotaCanvasGroup.alpha = 1f;
            panelDerrotaCanvasGroup.interactable = true;
            panelDerrotaCanvasGroup.blocksRaycasts = true;
        }
    }

    void ActualizarHUD()
    {
        for (int i = 0; i < vidasHUD.Length; i++)
        {
            if (i < vidas)
            {
                vidasHUD[i].enabled = true;
            }
            else
            {
                vidasHUD[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PerderVida();
            Destroy(other.gameObject);
        }
    }
}