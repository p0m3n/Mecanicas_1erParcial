using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Llama esta funci�n desde el bot�n "Iniciar Juego"
    public void IniciarJuego()
    {
        // Cambia el �ndice si tu escena del juego no es la 1
        SceneManager.LoadScene(1);
    }

    // Llama esta funci�n desde el bot�n "Salir del Juego"
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Solo funciona en el ejecutable, no en el editor
    }
}
