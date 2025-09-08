using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public string nombreMusica; // "Cuarto1", "Cuarto2", etc.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicManager>().CambiarMusica(nombreMusica);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicManager>().CambiarMusica("Exploracion");
        }
    }
}
