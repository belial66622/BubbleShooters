using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSphere : MonoBehaviour
{
    [SerializeField]
    float radius= 2;

    [SerializeField] 
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0, layerMask);

        if (Hit.Length > 0)
        {
            foreach (RaycastHit2D hit in Hit)
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
