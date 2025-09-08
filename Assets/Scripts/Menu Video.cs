using UnityEngine;
using UnityEngine.Video;

public class MenuVideo : MonoBehaviour
{
    public VideoClip[] videos; // Asignas 2 videoclips desde el Inspector
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videos.Length > 0)
        {
            int aleatorio = Random.Range(0, videos.Length);
            videoPlayer.clip = videos[aleatorio];
            videoPlayer.Play();
        }
    }
}
