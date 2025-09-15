using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PantallaDerrotaController : MonoBehaviour
{
    public GameObject panelDerrota;
    private CanvasGroup canvasGroup;

    [Header("Opciones de Fade")]
    [Tooltip("Duración del efecto fade-in en segundos")]
    public float fadeDuration = 1.5f;

    private void Start()
    {
        if (panelDerrota != null)
        {
            panelDerrota.SetActive(false);
            canvasGroup = panelDerrota.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
                canvasGroup.alpha = 0f;
        }

        // Por si venías de otra música activa
        MusicManager mm = FindObjectOfType<MusicManager>();
        if (mm != null)
            mm.CambiarMusica("Exploracion");
    }

    private void Update()
    {
        //Simulación temporal: tecla L para probar la pantalla de derrota
        if (Input.GetKeyDown(KeyCode.L))
        {
            MostrarPantallaDerrota();
        }
    }

    public void MostrarPantallaDerrota()
    {
        if (panelDerrota != null)
        {
            panelDerrota.SetActive(true);
            StartCoroutine(FadeInDerrota());
            Time.timeScale = 0f;

            MusicManager mm = FindObjectOfType<MusicManager>();
            if (mm != null)
                mm.CambiarMusica("Derrota");
        }
    }

    private IEnumerator FadeInDerrota()
    {
        float elapsed = 0f;
        if (canvasGroup == null) yield break;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Version 8");
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
