using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referensi ke transform pemain
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset posisi kamera terhadap pemain
    public float smoothSpeed = 5f; // Kecepatan pergerakan kamera (untuk efek halus)

    void LateUpdate()
    {
        if (player != null)
        {
            // Hitung posisi target kamera
            Vector3 targetPosition = player.position + offset;

            // Pindahkan kamera secara halus ke posisi target
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
