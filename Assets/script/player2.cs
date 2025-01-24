using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan gerakan karakter
    private Vector2 moveDirection;

    void Update()
    {
        // Reset arah gerakan setiap frame
        moveDirection = Vector2.zero;

        // Cek input tombol untuk gerakan
        if (Input.GetKey(KeyCode.UpArrow))  // Gerak ke atas
            moveDirection.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow))  // Gerak ke bawah
            moveDirection.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow))  // Gerak ke kiri
            moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow))  // Gerak ke kanan
            moveDirection.x = 1f;

        // Normalisasi arah gerakan agar kecepatannya tetap konsisten meskipun diagonal
        moveDirection.Normalize();

        // Menggerakkan karakter berdasarkan input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}