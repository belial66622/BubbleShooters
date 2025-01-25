using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeControl : MonoBehaviour
{
    BladeHealth[] ThisObjectBlade;
    private void Awake()
    {
        ThisObjectBlade = GetComponentsInChildren<BladeHealth>();
    }


    public void ChangeLevelDurability()
    {
        foreach (var blade in ThisObjectBlade)
        {
            blade.DurabilityLevelUp();
        }
    }
}
