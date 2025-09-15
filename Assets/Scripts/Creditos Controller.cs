//using System;
//using System.Collections;
//using UnityEngine;
//using TMPro;
//using UnityEngine.SceneManagement;

//public class CreditosController : MonoBehaviour
//{
//    [Header("Creditos")]
//    public GameObject panelCreditos;
//    public TextMeshProUGUI[] creditos;
//    public TextMeshProUGUI textoFinal;

//    [Header("Música")]
//    public AudioSource musicaCreditos;
//    public float duracionFadeMusica = 2f;

//    [Header("Animación")]
//    public float duracionFadeTexto = 1f;
//    public float velocidadSubida = 30f;
//    public float intervaloEntreTextos = 1.5f;

//    [Header("Transición final")]
//    public float esperaAntesDeSalir = 3f;
//    public float duracionFadeFinal = 1.2f;

//    private bool saltar = false;
//    private Vector2 posicionBase;

//    public void IniciarCreditos()
//    {
//        StartCoroutine(MostrarCreditos(() =>
//        {
//            SceneManager.LoadScene("MenuPrincipal"); // Cambia al nombre real de tu menú
//        }));
//    }

//    public IEnumerator MostrarCreditos(Action alFinalizar)
//    {
//        if (panelCreditos != null)
//        {
//            panelCreditos.SetActive(true);
//            CanvasGroup cg = panelCreditos.GetComponent<CanvasGroup>();
//            if (cg != null)
//            {
//                cg.alpha = 1f;
//                cg.interactable = false;
//                cg.blocksRaycasts = true;
//            }
//        }

//        if (creditos.Length > 0)
//            posicionBase = creditos[0].rectTransform.anchoredPosition;

//        if (musicaCreditos != null)
//            musicaCreditos.Play();

//        StartCoroutine(EscListener(alFinalizar));

//        for (int i = 0; i < creditos.Length; i++)
//        {
//            if (saltar) yield break;

//            creditos[i].rectTransform.anchoredPosition = posicionBase;
//            yield return StartCoroutine(FadeIn(creditos[i]));
//            StartCoroutine(MoverHaciaArriba(creditos[i].rectTransform));
//            yield return new WaitForSecondsRealtime(intervaloEntreTextos);
//        }

//        if (!saltar && textoFinal != null)
//        {
//            textoFinal.rectTransform.anchoredPosition = posicionBase;
//            yield return StartCoroutine(FadeIn(textoFinal));
//            StartCoroutine(MoverHaciaArriba(textoFinal.rectTransform));
//        }

//        yield return new WaitForSecondsRealtime(esperaAntesDeSalir);

//        if (musicaCreditos != null)
//            yield return StartCoroutine(FadeOutMusica());

//        if (panelCreditos != null)
//            yield return StartCoroutine(FadeOutPanel(panelCreditos, duracionFadeFinal));

//        alFinalizar?.Invoke();
//    }

//    private IEnumerator FadeIn(TextMeshProUGUI texto)
//    {
//        Color c = texto.color;
//        c.a = 0;
//        texto.color = c;

//        float t = 0;
//        while (t < duracionFadeTexto)
//        {
//            t += Time.unscaledDeltaTime;
//            c.a = Mathf.Lerp(0, 1, t / duracionFadeTexto);
//            texto.color = c;
//            yield return null;
//        }
//    }

//    private IEnumerator MoverHaciaArriba(RectTransform rt)
//    {
//        while (true)
//        {
//            rt.anchoredPosition += new Vector2(0, velocidadSubida * Time.unscaledDeltaTime);
//            yield return null;
//        }
//    }

//    private IEnumerator FadeOutMusica()
//    {
//        float t = 0f;
//        float inicial = musicaCreditos.volume;

//        while (t < duracionFadeMusica)
//        {
//            t += Time.unscaledDeltaTime;
//            musicaCreditos.volume = Mathf.Lerp(inicial, 0f, t / duracionFadeMusica);
//            yield return null;
//        }

//        musicaCreditos.Stop();
//        musicaCreditos.volume = inicial;
//    }

//    private IEnumerator EscListener(Action alFinalizar)
//    {
//        while (!saltar)
//        {
//            if (Input.GetKeyDown(KeyCode.Escape))
//            {
//                saltar = true;

//                if (musicaCreditos != null)
//                    musicaCreditos.Stop();

//                if (panelCreditos != null)
//                    yield return StartCoroutine(FadeOutPanel(panelCreditos, duracionFadeFinal));

//                alFinalizar.Invoke();
//                break;
//            }

//            yield return null;
//        }
//    }

//    private IEnumerator FadeOutPanel(GameObject panel, float duration)
//    {
//        CanvasGroup cg = panel.GetComponent<CanvasGroup>();
//        if (cg == null) yield break;

//        float t = 0f;
//        float alphaInicial = cg.alpha;

//        cg.interactable = false;
//        cg.blocksRaycasts = false;

//        while (t < duration)
//        {
//            t += Time.unscaledDeltaTime;
//            cg.alpha = Mathf.Lerp(alphaInicial, 0f, t / duration);
//            yield return null;
//        }

//        cg.alpha = 0f;
//        panel.SetActive(false);
//    }
//}


using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    [Header("Creditos")]
    public GameObject panelCreditos;
    public TextMeshProUGUI[] creditos;
    public TextMeshProUGUI textoFinal;

    [Header("Animación")]
    public float duracionFadeTexto = 1f;
    public float velocidadSubida = 30f;
    public float intervaloEntreTextos = 1.5f;

    [Header("Transición final")]
    public float esperaAntesDeSalir = 3f;
    public float duracionFadeFinal = 1.2f;

    private bool saltar = false;
    private Vector2 posicionBase;
    private MusicManager musicManager;

    public void IniciarCreditos()
    {
        StartCoroutine(MostrarCreditos(() =>
        {
            SceneManager.LoadScene("MenuPrincipal"); // Cambia si tu menú tiene otro nombre
        }));
    }

    public IEnumerator MostrarCreditos(Action alFinalizar)
    {
        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
            musicManager.CambiarMusica("Outro");

        if (panelCreditos != null)
        {
            panelCreditos.SetActive(true);
            CanvasGroup cg = panelCreditos.GetComponent<CanvasGroup>();
            if (cg != null)
            {
                cg.alpha = 1f;
                cg.interactable = false;
                cg.blocksRaycasts = true;
            }
        }

        if (creditos.Length > 0)
            posicionBase = creditos[0].rectTransform.anchoredPosition;

        StartCoroutine(EscListener(alFinalizar));

        for (int i = 0; i < creditos.Length; i++)
        {
            if (saltar) yield break;

            creditos[i].rectTransform.anchoredPosition = posicionBase;
            yield return StartCoroutine(FadeIn(creditos[i]));
            StartCoroutine(MoverHaciaArriba(creditos[i].rectTransform));
            yield return new WaitForSecondsRealtime(intervaloEntreTextos);
        }

        if (!saltar && textoFinal != null)
        {
            textoFinal.rectTransform.anchoredPosition = posicionBase;
            yield return StartCoroutine(FadeIn(textoFinal));
            StartCoroutine(MoverHaciaArriba(textoFinal.rectTransform));
        }

        yield return new WaitForSecondsRealtime(esperaAntesDeSalir);
        yield return StartCoroutine(FadeOutPanel(panelCreditos, duracionFadeFinal));

        alFinalizar?.Invoke();
    }

    private IEnumerator FadeIn(TextMeshProUGUI texto)
    {
        Color c = texto.color;
        c.a = 0;
        texto.color = c;

        float t = 0;
        while (t < duracionFadeTexto)
        {
            t += Time.unscaledDeltaTime;
            c.a = Mathf.Lerp(0, 1, t / duracionFadeTexto);
            texto.color = c;
            yield return null;
        }
    }

    private IEnumerator MoverHaciaArriba(RectTransform rt)
    {
        while (true)
        {
            rt.anchoredPosition += new Vector2(0, velocidadSubida * Time.unscaledDeltaTime);
            yield return null;
        }
    }

    private IEnumerator EscListener(Action alFinalizar)
    {
        while (!saltar)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                saltar = true;

                if (panelCreditos != null)
                    yield return StartCoroutine(FadeOutPanel(panelCreditos, duracionFadeFinal));

                alFinalizar.Invoke();
                break;
            }

            yield return null;
        }
    }

    private IEnumerator FadeOutPanel(GameObject panel, float duration)
    {
        CanvasGroup cg = panel.GetComponent<CanvasGroup>();
        if (cg == null) yield break;

        float t = 0f;
        float alphaInicial = cg.alpha;

        cg.interactable = false;
        cg.blocksRaycasts = false;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = Mathf.Lerp(alphaInicial, 0f, t / duration);
            yield return null;
        }

        cg.alpha = 0f;
        panel.SetActive(false);
    }
}
