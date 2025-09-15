
//using UnityEngine;
//using TMPro;
//using System.Collections;

//public class IntroCinematicaSimple : MonoBehaviour
//{
//    [Header("Textos")]
//    public TextMeshProUGUI[] textos;
//    public TextMeshProUGUI textoFinal;

//    [Header("Panel de introducción")]
//    public GameObject panelIntro;

//    [Header("Control del jugador")]
//    public GameObject jugador;

//    [Header("Movimiento de texto")]
//    public float espacioEntreTextos = 60f;
//    public float duracionFade = 1f;
//    public float velocidadSubida = 30f;

//    [Header("Música")]
//    public AudioSource musicaIntro;
//    public float duracionFadeMusica = 2f;

//    private Vector2 posicionBase;

//    void Start()
//    {
//        if (jugador != null)
//            jugador.SetActive(false);

//        posicionBase = textos[0].rectTransform.anchoredPosition;

//        if (musicaIntro != null)
//            musicaIntro.Play();

//        StartCoroutine(ReproducirCinematica());
//    }

//    IEnumerator ReproducirCinematica()
//    {
//        for (int i = 0; i < textos.Length; i++)
//        {
//            textos[i].rectTransform.anchoredPosition = posicionBase;
//            yield return StartCoroutine(FadeIn(textos[i]));
//            StartCoroutine(MoverHaciaArriba(textos[i].rectTransform));
//            yield return new WaitForSeconds(1.5f);
//        }

//        yield return StartCoroutine(FadeIn(textoFinal));

//        yield return StartCoroutine(EsperarTeclaPresionada());

//        if (musicaIntro != null)
//            yield return StartCoroutine(FadeOutMusica());

//        yield return StartCoroutine(FadeOutPanel(panelIntro, 1.2f));

//        if (jugador != null)
//            jugador.SetActive(true);
//    }

//    IEnumerator FadeIn(TextMeshProUGUI texto)
//    {
//        Color c = texto.color;
//        c.a = 0;
//        texto.color = c;

//        float t = 0;
//        while (t < duracionFade)
//        {
//            t += Time.deltaTime;
//            c.a = Mathf.Lerp(0, 1, t / duracionFade);
//            texto.color = c;
//            yield return null;
//        }
//    }

//    IEnumerator MoverHaciaArriba(RectTransform rt)
//    {
//        while (true)
//        {
//            rt.anchoredPosition += new Vector2(0, velocidadSubida * Time.deltaTime);
//            yield return null;
//        }
//    }

//    IEnumerator FadeOutMusica()
//    {
//        float tiempo = 0f;
//        float volumenInicial = musicaIntro.volume;

//        while (tiempo < duracionFadeMusica)
//        {
//            tiempo += Time.deltaTime;
//            musicaIntro.volume = Mathf.Lerp(volumenInicial, 0f, tiempo / duracionFadeMusica);
//            yield return null;
//        }

//        musicaIntro.Stop();
//        musicaIntro.volume = volumenInicial;
//    }

//    IEnumerator EsperarTeclaPresionada()
//    {
//        while (!Input.anyKeyDown)
//        {
//            yield return null;
//        }
//    }

//    IEnumerator FadeOutPanel(GameObject panel, float duration)
//    {
//        CanvasGroup cg = panel.GetComponent<CanvasGroup>();
//        if (cg == null) yield break;

//        float t = 0f;
//        float alphaInicial = cg.alpha;

//        cg.interactable = false;
//        cg.blocksRaycasts = false;

//        while (t < duration)
//        {
//            t += Time.deltaTime;
//            cg.alpha = Mathf.Lerp(alphaInicial, 0f, t / duration);
//            yield return null;
//        }

//        cg.alpha = 0f;
//        panel.SetActive(false);
//    }
//}


using UnityEngine;
using TMPro;
using System.Collections;

public class IntroCinematicaSimple : MonoBehaviour
{
    [Header("Textos")]
    public TextMeshProUGUI[] textos;
    public TextMeshProUGUI textoFinal;

    [Header("Panel de introducción")]
    public GameObject panelIntro;

    [Header("Control del jugador")]
    public GameObject jugador;

    [Header("Movimiento de texto")]
    public float espacioEntreTextos = 60f;
    public float duracionFade = 1f;
    public float velocidadSubida = 30f;

    [Header("Fade de música global (solo visual)")]
    public float duracionFadeMusica = 2f;

    private Vector2 posicionBase;
    private MusicManager musicManager;

    void Start()
    {
        if (jugador != null)
            jugador.SetActive(false);

        posicionBase = textos[0].rectTransform.anchoredPosition;

        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
            musicManager.CambiarMusica("Intro");

        StartCoroutine(ReproducirCinematica());
    }

    IEnumerator ReproducirCinematica()
    {
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].rectTransform.anchoredPosition = posicionBase;
            yield return StartCoroutine(FadeIn(textos[i]));
            StartCoroutine(MoverHaciaArriba(textos[i].rectTransform));
            yield return new WaitForSeconds(1.5f);
        }

        yield return StartCoroutine(FadeIn(textoFinal));

        yield return StartCoroutine(EsperarTeclaPresionada());

        // No hacemos FadeOut real de música porque MusicManager la gestiona
        yield return StartCoroutine(FadeOutPanel(panelIntro, 1.2f));

        if (jugador != null)
            jugador.SetActive(true);

        // Puedes cambiar la música al gameplay
        if (musicManager != null)
            musicManager.CambiarMusica("Exploracion");
    }

    IEnumerator FadeIn(TextMeshProUGUI texto)
    {
        Color c = texto.color;
        c.a = 0;
        texto.color = c;

        float t = 0;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / duracionFade);
            texto.color = c;
            yield return null;
        }
    }

    IEnumerator MoverHaciaArriba(RectTransform rt)
    {
        while (true)
        {
            rt.anchoredPosition += new Vector2(0, velocidadSubida * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator EsperarTeclaPresionada()
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
    }

    IEnumerator FadeOutPanel(GameObject panel, float duration)
    {
        CanvasGroup cg = panel.GetComponent<CanvasGroup>();
        if (cg == null) yield break;

        float t = 0f;
        float alphaInicial = cg.alpha;

        cg.interactable = false;
        cg.blocksRaycasts = false;

        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(alphaInicial, 0f, t / duration);
            yield return null;
        }

        cg.alpha = 0f;
        panel.SetActive(false);
    }
}
