using UnityEngine;

public class RotateAroundParent : MonoBehaviour
{
    public Transform parentObject; // Objek parent yang akan dikelilingi
    
    public float radius = 2f; // Jarak dari objek parent
    public float rotationSpeed = 50f; // Kecepatan rotasi mengelilingi parent dalam derajat per detik
    public float selfRotationSpeed = 100f; // Kecepatan rotasi objek sendiri dalam derajat per detik

    private float angle; // Sudut rotasi objek di sekitar parent

    void Start()
    {
        if (parentObject != null)
        {
            // Menentukan sudut awal secara acak
            angle = Random.Range(0f, 360f);

            // Menghitung posisi awal berdasarkan sudut acak
            float radian = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            transform.position = parentObject.position + offset;

            // Menentukan rotasi awal objek secara acak
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        }
    }

    void Update()
    {
        if (parentObject != null)
        {
            // Menghitung sudut rotasi berdasarkan kecepatan dan waktu
            angle += rotationSpeed * Time.deltaTime;

            // Mengkonversi sudut ke radian
            float radian = angle * Mathf.Deg2Rad;

            // Menghitung posisi objek berdasarkan radius dan sudut
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            transform.position = parentObject.position + offset;

            // Menambahkan rotasi lokal pada objek
            transform.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime);
        }
    }

    // Fungsi untuk menangani tabrakan
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika tabrakan dengan objek bertag "bubble", maka bubble beserta childnya dinonaktifkan
        if (collision.gameObject.CompareTag("weapon"))
        {
            Debug.Log("Tabrakan dengan bubble terdeteksi.");
            collision.gameObject.SetActive(false); // Menonaktifkan bubble dan semua child-nya
            
        }
        // Jika tabrakan dengan objek bertag "weapon", maka objek ini (dengan script ini) dinonaktifkan
        else if (collision.gameObject.CompareTag("bubble"))
        {
            Debug.Log("Tabrakan dengan weapon terdeteksi.");
            gameObject.SetActive(false); // Menonaktifkan objek ini
        }
    }
}



