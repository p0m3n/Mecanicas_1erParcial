//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class PantallaVictoriaController : MonoBehaviour
//{
//    [Header("UI")]
//    public GameObject panelVictoria;
//    private CanvasGroup canvasGroup;

//    [Header("Créditos")]
//    public CreditosController creditosController;

//    [Header("Música")]
//    public AudioSource musicaVictoria;

//    [Header("Fade")]
//    public float fadeDuration = 1.5f;

//    private void Start()
//    {
//        if (panelVictoria != null)
//        {
//            panelVictoria.SetActive(false);
//            canvasGroup = panelVictoria.GetComponent<CanvasGroup>();
//            if (canvasGroup != null)
//                canvasGroup.alpha = 0f;
//        }

//        if (musicaVictoria != null)
//            musicaVictoria.Stop();
//    }

//    private void Update()
//    {
//        // Para pruebas: presiona V para forzar victoria
//        if (Input.GetKeyDown(KeyCode.V))
//        {
//            MostrarPantallaVictoria();
//        }
//    }

//    public void MostrarPantallaVictoria()
//    {
//        if (panelVictoria == null) return;

//        panelVictoria.SetActive(true);
//        Time.timeScale = 0f;

//        StartCoroutine(FadeInVictoria(() =>
//        {
//            if (musicaVictoria != null)
//                musicaVictoria.Play();

//            // Ya no se llaman los créditos automáticamente aquí
//            // Ahora solo se muestran si el jugador hace clic en un botón
//        }));
//    }

//    private IEnumerator FadeInVictoria(System.Action alFinalizar)
//    {
//        float elapsed = 0f;
//        if (canvasGroup == null) yield break;

//        while (elapsed < fadeDuration)
//        {
//            elapsed += Time.unscaledDeltaTime;
//            canvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
//            yield return null;
//        }

//        canvasGroup.alpha = 1f;
//        alFinalizar?.Invoke();
//    }

//    public void VolverAlMenu()
//    {
//        Time.timeScale = 1f;
//        if (musicaVictoria != null)
//            musicaVictoria.Stop();
//        SceneManager.LoadScene("Menu");
//    }

//    // 🔘 Este método se conecta al botón "Ver Créditos" (opcional)
//    public void MostrarCreditosDesdeBoton()
//    {
//        if (creditosController != null)
//        {
//            StartCoroutine(creditosController.MostrarCreditos(() =>
//            {
//                Time.timeScale = 1f;
//                if (musicaVictoria != null)
//                    musicaVictoria.Stop();
//                SceneManager.LoadScene("Menu");
//            }));
//        }
//    }
//}


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PantallaVictoriaController : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelVictoria;
    private CanvasGroup canvasGroup;

    [Header("Créditos")]
    public CreditosController creditosController;

    [Header("Fade")]
    public float fadeDuration = 1.5f;

    private void Start()
    {
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(false);
            canvasGroup = panelVictoria.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
                canvasGroup.alpha = 0f;
        }

        // Por si acaso venías de otra música
        MusicManager mm = FindObjectOfType<MusicManager>();
        if (mm != null)
            mm.CambiarMusica("Exploracion"); // o "Intro", según contexto
    }

    private void Update()
    {
        // Atajo de prueba con tecla V
        if (Input.GetKeyDown(KeyCode.V))
        {
            MostrarPantallaVictoria();
        }
    }

    public void MostrarPantallaVictoria()
    {
        if (panelVictoria == null) return;

        panelVictoria.SetActive(true);
        Time.timeScale = 0f;

        StartCoroutine(FadeInVictoria(() =>
        {
            MusicManager mm = FindObjectOfType<MusicManager>();
            if (mm != null)
                mm.CambiarMusica("Victoria");
        }));
    }

    private IEnumerator FadeInVictoria(System.Action alFinalizar)
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
        alFinalizar?.Invoke();
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Version 8");
    }

    public void MostrarCreditosDesdeBoton()
    {
        if (creditosController != null)
        {
            StartCoroutine(creditosController.MostrarCreditos(() =>
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Version 8");
            }));
        }
    }
}
