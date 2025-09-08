using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Zonas de juego")]
    public AudioClip exploracionMusic;
    public AudioClip pausaMusic;
    //public AudioClip cuarto1Music;
    //public AudioClip cuarto2Music;
    //public AudioClip cuarto3Music;
    //public AudioClip cuarto4Music;

    [Header("Escenas y paneles UI")]
    //public AudioClip introMusic;
    //public AudioClip outroMusic;
    public AudioClip victoriaMusic;
    public AudioClip derrotaMusic;

    private string musicaActual = "";

    AudioMixerGroup mixerGrupoEfectos;

    private void Start()
    {
        CambiarMusica("Exploracion"); // Puedes cambiar a "Intro" si quieres que empiece con la intro
    }

    public void CambiarMusica(string nombre)
    {
        if (musicaActual == nombre) return;

        musicaActual = nombre;

        switch (nombre)
        {
            case "Exploracion":
                audioSource.clip = exploracionMusic;
                break;
            //case "Cuarto1":
            //    audioSource.clip = cuarto1Music;
            //    break;
            //case "Cuarto2":
            //    audioSource.clip = cuarto2Music;
            //    break;
            //case "Cuarto3":
            //    audioSource.clip = cuarto3Music;
            //    break;
            //case "Cuarto4":
            //    audioSource.clip = cuarto4Music;
            //    break;
            //case "Intro":
            //    audioSource.clip = introMusic;
            //    break;
            //case "Outro":
            //    audioSource.clip = outroMusic;
            //    break;
            case "Victoria":
                audioSource.clip = victoriaMusic;
                break;
            case "Derrota":
                audioSource.clip = derrotaMusic;
                break;
            case "Pausa":
                audioSource.clip = pausaMusic;
                break;
            default:
                Debug.LogWarning("Nombre de música no reconocido: " + nombre);
                return;
        }

        audioSource.loop = true;
        audioSource.Play();
    }
}
