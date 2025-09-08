using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SfxVolumeManager : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider; // Slider for SFX volume

    [Header("Mixer")]
    public AudioMixer audioMixer; // Reference to the AudioMixer

    private void Start()
    {
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            Load();
        }
        else
        {
            Load(); // Ensure default load if no saved value
        }
    }

    public void ChangeSfxVolume()
    {
        if (sfxSlider != null && audioMixer != null)
        {
            float volume = sfxSlider.value;
            float dB = volume <= 0.0001f ? -80f : Mathf.Log10(volume) * 20; // Convert to dB
            audioMixer.SetFloat("SfxVolume", dB); // Set SFX volume in AudioMixer
            Save();
        }
        else
        {
            Debug.LogError("SFX Slider or AudioMixer is not assigned in the Inspector!");
        }
    }

    private void Load()
    {
        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
            ChangeSfxVolume(); // Apply the loaded volume
        }
        else
        {
            Debug.LogError("SFX Slider is not assigned in the Inspector!");
        }
    }

    private void Save()
    {
        if (sfxSlider != null)
        {
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("SFX Slider is not assigned in the Inspector!");
        }
    }
}