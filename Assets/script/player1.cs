using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan gerakan karakter
    private Vector2 moveDirection;

    void Update()
    {
        // Reset arah gerakan setiap frame
        moveDirection = Vector2.zero;

        // Cek input tombol untuk gerakan
        if (Input.GetKey(KeyCode.W))  // Gerak ke atas
            moveDirection.y = 1f;
        if (Input.GetKey(KeyCode.S))  // Gerak ke bawah
            moveDirection.y = -1f;
        if (Input.GetKey(KeyCode.A))  // Gerak ke kiri
            moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.D))  // Gerak ke kanan
            moveDirection.x = 1f;

        // Normalisasi arah gerakan agar kecepatannya tetap konsisten meskipun diagonal
        moveDirection.Normalize();

        // Menggerakkan karakter berdasarkan input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    
}

