using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Referensi ke panel pengaturan
    public Slider volumeSlider; // Referensi ke slider volume

    private void Start()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false); // Panel pengaturan tidak aktif di awal
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume; // Sinkronkan slider dengan volume
            volumeSlider.onValueChanged.AddListener(SetVolume); // Tambahkan listener
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("hiddenobject");
    }

    public void Setting()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf); // Aktifkan/tutup panel
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Atur volume global
    }
}
