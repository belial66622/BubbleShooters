using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk mengakses SceneManager

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu; // UI untuk menu pause
    public List<GameObject> interactableObjects; // Daftar objek yang bisa diinteraksi saat pause
    public static bool isPaused;
    public GameObject set;

    private List<Collider2D> disabledColliders = new List<Collider2D>(); // Untuk menyimpan collider yang dinonaktifkan

    void Start()
    {
        PauseMenu.SetActive(false);
        set.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (set.activeSelf)
            {
                // Jika layar pengaturan aktif, nonaktifkan layar pengaturan dan kembali ke permainan
                set.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
            else if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Nonaktifkan semua collider kecuali pada objek yang dapat diinteraksi
        DisableCollidersExceptInteractable();
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Aktifkan kembali semua collider
        EnableAllColliders();
    }

    public void settin()
    {
        PauseMenu.SetActive(false);
        set.SetActive(true);
    }

    public void back()
    {
        set.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void QuitToMenu()
    {
        // Memuat scene menu utama
        Time.timeScale = 1f; // Pastikan waktu berjalan normal
        SceneManager.LoadScene("menu"); // Ganti "menu" dengan nama scene menu Anda
    }

    private void DisableCollidersExceptInteractable()
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D collider in allColliders)
        {
            if (!IsInInteractableList(collider.gameObject))
            {
                if (collider.enabled)
                {
                    collider.enabled = false;
                    disabledColliders.Add(collider); // Simpan collider yang dinonaktifkan
                }
            }
        }
    }

    private void EnableAllColliders()
    {
        foreach (Collider2D collider in disabledColliders)
        {
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
        disabledColliders.Clear();
    }

    private bool IsInInteractableList(GameObject obj)
    {
        return interactableObjects.Contains(obj);
    }
}
