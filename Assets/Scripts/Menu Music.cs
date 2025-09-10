using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip[] musicas; // Asigna 2 clips desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicas.Length > 0)
        {
            int aleatorio = Random.Range(0, musicas.Length);
            audioSource.clip = musicas[aleatorio];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
