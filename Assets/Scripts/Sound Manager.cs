using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio")]
    public AudioSource efectosSource;
    //public AudioMixerGroup mixerGrupoEfectos;

    [Header("Clips de sonido")]
    //public AudioClip sonidoGema;
    //public AudioClip sonidoPuerta;
    //public AudioClip sonidoPuertaBoss;
    //public AudioClip sonidoElevadorSube;
    //public AudioClip sonidoElevadorBaja;
    //public AudioClip sonidoLava;
    //public AudioClip sonidoCambioArma;
    public AudioClip sonidoCaminar;
    public AudioClip sonidoSalto;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoDisparo;
    //public AudioClip sonidoEspada;
    //public AudioClip sonidoCrossbow;
    //public AudioClip sonidoCorrer;
    //public AudioClip sonidoFuego;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ReproducirEfecto(AudioClip clip)
    {
        if (clip != null && efectosSource != null)
        {
            efectosSource.PlayOneShot(clip);
        }
    }

    // Accesos directos
    //public void ReproducirSonidoGema()
    //{
    //    ReproducirEfecto(sonidoGema);
    //}

    //public void ReproducirSonidoPuerta()
    //{
    //    ReproducirEfecto(sonidoPuerta);
    //}

    public void ReproducirSalto()
    {
        ReproducirEfecto(sonidoSalto);
    }

    //public void ReproducirSonidoPuertaBoss()
    //{
    //    ReproducirEfecto(sonidoPuertaBoss);
    //}

    //public void ReproducirSonidoElevadorSube()
    //{
    //    ReproducirEfecto(sonidoElevadorSube);
    //}

    //public void ReproducirSonidoElevadorBaja()
    //{
    //    ReproducirEfecto(sonidoElevadorBaja);
    //}
    //public void ReproducirSonidoLava()
    //{
    //    if (efectosSource != null && sonidoLava != null)
    //    {
    //        efectosSource.volume = 0.2f; // 🔊 Baja el volumen solo para la lava
    //        efectosSource.loop = true;
    //        efectosSource.clip = sonidoLava;
    //        efectosSource.Play();
    //    }
    //}

    //public void DetenerLava()
    //{
    //    efectosSource.Stop();
    //    efectosSource.volume = 1f; // 🔁 Restaura volumen original
    //}



    //public void ReproducirCambioArma()
    //{
    //    ReproducirEfecto(sonidoCambioArma);
    //}
    public void ReproducirCaminar()
    {
        ReproducirEfecto(sonidoCaminar);
    }
    public void ReproducirMuerte()
    {
        ReproducirEfecto(sonidoMuerte);
    }
    public void ReproducirDisparo()
    {
        ReproducirEfecto(sonidoDisparo);
    }
    //public void ReproducirEspada()
    //{
    //    ReproducirEfecto(sonidoEspada);
    //}
    //public void ReproducirCrossbow()
    //{
    //    ReproducirEfecto(sonidoCrossbow);
    //}
    //public void ReproducirCorrer()
    //{
    //    ReproducirEfecto(sonidoCorrer);
    //}
    //public void ReproducirFuego()
    //{
    //    ReproducirEfecto(sonidoCorrer);
    //}


}
