using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public CanvasGroup winPanelCanvasGroup;
    public float timeRemaining = 120;
    private bool timerIsRunning = false;

    private void Start()
    {
        if (winPanelCanvasGroup != null)
        {
            winPanelCanvasGroup.alpha = 0f;
            winPanelCanvasGroup.gameObject.SetActive(false);
        }

        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                PlayerWins();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PlayerWins()
    {

        if (winPanelCanvasGroup != null)
        {
            winPanelCanvasGroup.gameObject.SetActive(true);

            winPanelCanvasGroup.alpha = 1f;
            winPanelCanvasGroup.interactable = true;
            winPanelCanvasGroup.blocksRaycasts = true;
        }

        Time.timeScale = 0f;
    }
}
