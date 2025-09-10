using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    public InputAction pause;

    [Header("UI")]
    public GameObject panelPausa;

    [Header("Música")]
    public AudioSource musicaFondo;

    [Header("Paneles activos en otros estados")]
    //public GameObject panelIntro;
    public GameObject panelVictoria;
    public GameObject panelDerrota;
    //public GameObject panelCreditos;

    private bool enPausa = false;

    private void Start()
    {
        pause = InputSystem.actions.FindAction("Pause");
        if (panelPausa != null)
            panelPausa.SetActive(false);
    }

    private void Update()
    {
        if (pause != null && pause.WasPressedThisFrame()) // Fix: Check if the InputAction was pressed this frame
        {
            Debug.Log("Pause");
            if (PuedePausar())
            {
                if (!enPausa)
                    PausarJuego();
                else
                    ReanudarJuego();
            }
        }
    }

    private bool PuedePausar()
    {
        // Solo permite pausar si NO está activo ninguno de estos paneles
        return /*!panelIntro.activeSelf &&*/
               !panelVictoria.activeSelf &&
               !panelDerrota.activeSelf;
               //!panelCreditos.activeSelf;
    }

    public void PausarJuego()
    {
        if (panelPausa != null)
            panelPausa.SetActive(true);

        if (musicaFondo != null && musicaFondo.isPlaying)
            musicaFondo.Pause();

        Time.timeScale = 0f;
        enPausa = true;
    }

    public void ReanudarJuego()
    {
        if (panelPausa != null)
            panelPausa.SetActive(false);

        if (musicaFondo != null)
            musicaFondo.UnPause();

        Time.timeScale = 1f;
        enPausa = false;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Version 8");
    }
}
