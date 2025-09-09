using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro
using UnityEngine.SceneManagement; // Necesario si quieres cambiar de escena

public class GameTimer : MonoBehaviour
{
    [Header("Componentes")]
    public TMP_Text timerText; // Arrastra aquí tu objeto de texto del temporizador
    public GameObject winPanel; // Arrastra aquí tu panel de victoria

    [Header("Configuración del Temporizador")]
    public float timeRemaining = 120; // Tiempo en segundos (ej. 120 segundos = 2 minutos)
    private bool timerIsRunning = false;

    private void Start()
    {
        // Asegúrate de que el panel de victoria esté oculto al empezar
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        // Inicia el temporizador
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Resta el tiempo que ha pasado desde el último frame
                timeRemaining -= Time.deltaTime;
                // Actualiza el texto en la pantalla
                DisplayTime(timeRemaining);
            }
            else
            {
                // El tiempo se ha acabado
                Debug.Log("¡Se acabó el tiempo!");
                timeRemaining = 0;
                timerIsRunning = false;
                PlayerWins();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Asegurarse de que el tiempo no sea negativo
        timeToDisplay = Mathf.Max(0, timeToDisplay);

        // Calcula minutos y segundos
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formatea el texto para que siempre tenga dos dígitos (ej. 01:05)
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PlayerWins()
    {
        // ¡Aquí va la lógica de victoria!
        Debug.Log("¡El jugador ha ganado!");

        // Opción 1: Mostrar el panel de victoria
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Opción 2: Pausar el juego
        Time.timeScale = 0f; // Esto detiene todo movimiento, animaciones, etc.

        // Opción 3: Cargar una escena de "Victoria" o volver al menú principal
        // Recuerda añadir la escena en File -> Build Settings
        // SceneManager.LoadScene("WinScene"); 
    }
}