using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timeCount : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.SetText($"Time : 0");

        EventsSystem.OnTimeCountEvent = changeTime; 
    }

    private void changeTime(int change)
    {
        textMeshProUGUI.SetText($"Time : {change}");
    }
}
