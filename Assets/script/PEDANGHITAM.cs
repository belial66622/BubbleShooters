using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateParentWithChild : MonoBehaviour
{
    public Transform childObject; // Objek child yang akan bergerak mengikuti parent
    public float radius = 2f; // Jarak dari parent ke child
    public float rotationSpeed = 50f; // Kecepatan rotasi parent dalam derajat per detik
    public float selfRotationSpeed = 100f; // Kecepatan rotasi child sendiri dalam derajat per detik

    private float angle; // Sudut rotasi child di sekitar parent

    void Start()
    {
        if (childObject != null)
        {
            // Menentukan sudut awal secara acak
            angle = Random.Range(0f, 360f);

            // Menghitung posisi awal child berdasarkan sudut acak
            float radian = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            childObject.position = transform.position + offset;

            // Menentukan rotasi awal child secara acak
            childObject.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        }
    }

    void Update()
    {
        if (childObject != null)
        {
            // Menghitung sudut rotasi berdasarkan kecepatan dan waktu
            angle += rotationSpeed * Time.deltaTime;

            // Mengkonversi sudut ke radian
            float radian = angle * Mathf.Deg2Rad;

            // Menghitung posisi child berdasarkan radius dan sudut
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            childObject.position = transform.position + offset;

            // Menambahkan rotasi lokal pada child
            childObject.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika tabrakan dengan objek bertag "bubble", maka bubble beserta child-nya dinonaktifkan
        if (collision.gameObject.CompareTag("bubble"))
        {
            Debug.Log("Tabrakan dengan bubble terdeteksi.");
            collision.gameObject.SetActive(false); // Menonaktifkan bubble dan semua child-nya
        }
        // Jika tabrakan dengan objek bertag "weapon", maka parent ini beserta child-nya dinonaktifkan
        else if (collision.gameObject.CompareTag("weapon"))
        {
            Debug.Log("Tabrakan dengan weapon terdeteksi.");
            gameObject.SetActive(false); // Menonaktifkan parent ini
        }
    }
}

