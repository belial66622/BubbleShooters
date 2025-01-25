using UnityEngine;

public class RandomNumberExample : MonoBehaviour
{
    public int gacha;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        {
            gacha = Random.Range(1, 4); // Angka 1-100
            Debug.Log("Angka acak: " + gacha);
            gameObject.SetActive(false);
        }
    }
}
