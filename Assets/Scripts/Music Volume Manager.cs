using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMusicManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider; // Slider for music volume

    [Header("Mixer")]
    public AudioMixer audioMixer; // Reference to the AudioMixer

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Load();
        }
        else
        {
            Load(); // Ensure default load if no saved value
        }
    }

    public void ChangeVolume()
    {
        if (volumeSlider != null && audioMixer != null)
        {
            float volume = volumeSlider.value;
            float dB = volume <= 0.0001f ? -80f : Mathf.Log10(volume) * 20; // Convert to dB
            audioMixer.SetFloat("MusicVolume", dB); // Set music volume in AudioMixer
            Save();
        }
        else
        {
            Debug.LogError("Music Slider or AudioMixer is not assigned in the Inspector!");
        }
    }

    private void Load()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            ChangeVolume(); // Apply the loaded volume
        }
        else
        {
            Debug.LogError("Music Slider is not assigned in the Inspector!");
        }
    }

    private void Save()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Music Slider is not assigned in the Inspector!");
        }
    }
}