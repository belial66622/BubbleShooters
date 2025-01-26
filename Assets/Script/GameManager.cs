using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerList;

    [SerializeField]
    public List<Camera> CameraList;

    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    int b;

    private void Awake()
    {
        EventsSystem.OnRegisterPlayerEvent += AddPlayer;
    }

    private void OnDestroy()
    {
        EventsSystem.OnRegisterPlayerEvent -= AddPlayer;
    }
    private void AddPlayer(Transform player)
    {
        playerList.Add(player.gameObject);
    }

    public void gameover()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartCoroutine(TimeCount());
    }

    IEnumerator TimeCount()
    {
        float t = 0;
        while (true)
        {
            yield return null;
            if (t < 1)
            {
                t += Time.deltaTime;
            }
            else
            {
                b++;
                textMeshProUGUI.SetText($"Time : {b}");
                t = 0;
                if (!playerList.Exists(x => x.activeInHierarchy))
                { gameover(); }
            }
        }
    }
}
