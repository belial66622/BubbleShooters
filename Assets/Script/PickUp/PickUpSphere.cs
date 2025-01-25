using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSphere : MonoBehaviour
{
    [SerializeField]
    float radius= 2;

    [SerializeField] 
    LayerMask layerMask;

    [SerializeField]
     bool IsShowGUI = true;

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
                if (hit.transform.gameObject.TryGetComponent<PickUp>(out PickUp pickUp))
                {
                    pickUp.Picked(transform);
                }
            }
        }
    }


    public void OnDrawGizmos()
    {
        if (!IsShowGUI) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        //Gizmos.DrawSphere(transform.position, radius);
    }
}
