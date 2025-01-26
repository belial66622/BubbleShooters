using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField]
    BladeHealth[] durability;
    [SerializeField]
    Movement move;
    [SerializeField]
    rotate bladerotation;


    public void Levelup()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                foreach (var blade in durability)
                {
                    blade.DurabilityLevelUp();
                }
                break;
            case 2:
                move.movementspeed *= 1.1f;
                break;
            case 3:
                bladerotation.speed *= 1.1f;
                break;
        }
    }
}
