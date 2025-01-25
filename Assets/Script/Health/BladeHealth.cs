using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeHealth : Health
{
    public int Durability = 2;

    public GameObject Owner;

    Collider2D objColl;

    [SerializeField]
    LayerMask layermask;

    RaycastHit2D[] hitsaved;
    private void Awake()
    {
        objColl = GetComponent<Collider2D>();
    }

    public override void OnCollide(GameObject OtherGameObject)
    {
        Debug.Log("ada");
        Durability--;
        gameObject.SetActive(Durability > 0);
    }

    /* private void FixedUpdate()
     {
         RaycastHit2D[] other = Physics2D.BoxCastAll(transform.position, objColl.bounds.size, 0, Vector2.zero, 0, layermask);


         if (other.Length > 0)
         {
             foreach (var otherObject in other)
             {
                 if(hitsaved. .)
                 if (otherObject.transform.gameObject.TryGetComponent<Health>(out Health health))
                 {
                     if (health.GetType() == typeof(BladeHealth))
                     {
                         if (Owner == ((BladeHealth)health).Owner)
                         {
                             continue;
                         }
                     }

                     health.OnCollide(gameObject);

                 }
             }
         }
         hitsaved = other;
     }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            if (health.GetType() == typeof(BladeHealth))
            {
                if (Owner == ((BladeHealth)health).Owner)
                {
                    return;
                }
            }

            health.OnCollide(gameObject);

        }
    }
}
