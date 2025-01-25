using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : Health
{
    public override void OnCollide(GameObject OtherGameObject)
    {
        if (OtherGameObject.TryGetComponent(out BladeHealth other))
        {
            if (other.Owner != gameObject)
            {
                Death();               
            }
        }
    }

    public void Death()
    { 
        gameObject.SetActive(false);
    }
}
