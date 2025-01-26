using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumber : MonoBehaviour
{
    public int playerSpawn = 0;

    private void Awake()
    {
        playerSpawn = DataBeforeScene.PlayerPlay;
    }
    /*    private void Awake()
        {
            playerSpawn = DataBeforeScene.PlayerPlay;
        }*/
}
