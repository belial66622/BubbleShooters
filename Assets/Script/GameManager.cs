using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerList;

    [SerializeField]
    public List<Camera> CameraList;

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
}
