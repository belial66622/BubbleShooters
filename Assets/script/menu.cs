using UnityEngine;

public class MainMenuCameraController : MonoBehaviour
{
    [SerializeField] private Transform mainMenuPosition; // Posisi kamera untuk Main Menu
    [SerializeField] private Transform optionsPosition;  // Posisi kamera untuk Options Menu
    [SerializeField] private Transform creditsPosition;  // Posisi kamera untuk Credits Menu

    [SerializeField] private float transitionSpeed = 2f; // Kecepatan kamera bergeser

    private Transform targetPosition; // Posisi tujuan kamera

    private void Start()
    {
        // Awalnya kamera mengarah ke Main Menu
        targetPosition = mainMenuPosition;
        transform.position = mainMenuPosition.position;
    }

    private void Update()
    {
        // Geser kamera secara halus menuju posisi tujuan
        if (targetPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, transitionSpeed * Time.deltaTime);
        }
    }

    // Fungsi untuk mengatur tujuan kamera
    public void MoveToMainMenu()
    {
        targetPosition = mainMenuPosition;
    }

    public void MoveToOptions()
    {
        targetPosition = optionsPosition;
    }

    public void MoveToCredits()
    {
        targetPosition = creditsPosition;
    }

    public void quit()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }

    public void single()
    {
        
    }

    public void multi()
    {
        
    }
}
