using UnityEngine;

public class RotateAroundParent : MonoBehaviour
{
    public Transform parentObject; // Objek parent yang akan dikelilingi

    public float radius = 2f; // Jarak dari objek parent
    public float rotationSpeed = 50f; // Kecepatan rotasi mengelilingi parent dalam derajat per detik
    public float selfRotationSpeed = 100f; // Kecepatan rotasi objek sendiri dalam derajat per detik
    public string tagbub; // Tag objek bubble
    public string tagwea; // Tag objek weapon

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
            // Menghitung sudut rotasi berdasarkan kecepatan (searah jarum jam)
            angle -= rotationSpeed * Time.deltaTime; // Mengurangi sudut agar gerakan searah jarum jam

            // Mengkonversi sudut ke radian
            float radian = angle * Mathf.Deg2Rad;

            // Menghitung posisi objek berdasarkan radius dan sudut
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            transform.position = parentObject.position + offset;

            // Menambahkan rotasi lokal pada objek (rotasi dirinya sendiri)
            transform.Rotate(Vector3.forward, -selfRotationSpeed * Time.deltaTime); // Rotasi juga mengikuti arah jarum jam
        }
    }

    // Fungsi untuk menangani tabrakan
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika tabrakan dengan objek bertag "bubble", maka bubble beserta child-nya dinonaktifkan
        if (collision.gameObject.CompareTag(tagbub))
        {
            Debug.Log("Tabrakan dengan bubble terdeteksi.");
            collision.gameObject.SetActive(false);

            // Menonaktifkan semua objek dengan tag "weapon"
            GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag(tagwea);
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false); // Nonaktifkan objek
            }
        }
        // Jika tabrakan dengan objek bertag "weapon", maka parent ini beserta child-nya dinonaktifkan
        else if (collision.gameObject.CompareTag(tagwea))
        {
            Debug.Log("Tabrakan dengan weapon terdeteksi.");
            gameObject.SetActive(false); // Menonaktifkan objek ini
        }
    }
}




