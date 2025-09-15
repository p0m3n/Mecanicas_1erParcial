using UnityEngine;

public class FadeControles : MonoBehaviour
{
    public CanvasGroup panelControles;
    public float duracion = 0.5f;

    public void MostrarPanel()
    {
        panelControles.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void OcultarPanel()
    {
        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        panelControles.interactable = true;
        panelControles.blocksRaycasts = true;

        float t = 0;
        while (t < duracion)
        {
            t += Time.deltaTime;
            panelControles.alpha = Mathf.Lerp(0, 1, t / duracion);
            yield return null;
        }
        panelControles.alpha = 1;
    }

    private System.Collections.IEnumerator FadeOut()
    {
        panelControles.interactable = false;
        panelControles.blocksRaycasts = false;

        float t = 0;
        while (t < duracion)
        {
            t += Time.deltaTime;
            panelControles.alpha = Mathf.Lerp(1, 0, t / duracion);
            yield return null;
        }
        panelControles.alpha = 0;
        panelControles.gameObject.SetActive(false);
    }
}
