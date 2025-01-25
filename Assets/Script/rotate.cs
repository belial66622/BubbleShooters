using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float x = 0;
    [SerializeField]
    float speed = 10;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        x += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, x);
    }
}
