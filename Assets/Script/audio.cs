using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Scrollbar volumeScrollbar; // Scrollbar untuk mengatur volume
    public List<AudioSource> audioSources; // Daftar AudioSource yang akan dikontrol

    private float currentVolume = 1f; // Default volume (maksimum)

    void Start()
    {
        // Set nilai awal volume dari scrollbar
        if (volumeScrollbar != null)
        {
            volumeScrollbar.value = currentVolume; // Atur scrollbar ke volume awal
            volumeScrollbar.onValueChanged.AddListener(SetVolume); // Tambahkan listener untuk scrollbar
        }

        // Terapkan volume awal ke semua AudioSource
        UpdateAudioSourcesVolume(currentVolume);
    }

    public void SetVolume(float value)
    {
        currentVolume = value; // Simpan nilai volume saat ini
        UpdateAudioSourcesVolume(currentVolume); // Terapkan volume ke semua AudioSource
    }

    private void UpdateAudioSourcesVolume(float volume)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume; // Terapkan volume ke masing-masing AudioSource
            }
        }
    }
}
