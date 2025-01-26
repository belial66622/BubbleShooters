using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject pojo;
    public List<GameObject> playerList;

    [SerializeField]
    public List<Camera> CameraList;

    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    int b;

    [SerializeField]
    GameObject Gameover;

    bool isPaused = false;



    public void puase()
    {
        isPaused = !isPaused;
        pojo.SetActive(true);
        Time.timeScale = isPaused ? 0 : 1;
    }
    private void Awake()
    {
        EventsSystem.OnRegisterPlayerEvent += AddPlayer;
        EventsSystem.OnPausedEvent += puase;
    }

    private void OnDestroy()
    {
        EventsSystem.OnRegisterPlayerEvent -= AddPlayer;
        EventsSystem.OnPausedEvent -= puase;
    }
    private void AddPlayer(Transform player)
    {
        playerList.Add(player.gameObject);
    }

    public void gameover()
    {
        StopAllCoroutines();
        Gameover.SetActive(true);
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
