using UnityEngine;

public class rotate : MonoBehaviour
{
    float x = 0;
    [SerializeField]
    float speed = 10;
    // Update is called once per frame
    private void Awake()
    {
        int random = Random.Range(0,2);
        if (random == 0)
        {
            speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        x += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, x);
    }
}
