using System;
using UnityEngine;

public class XP : MonoBehaviour
{
    [SerializeField]
    int[] levelThreshold;

    int levelnow=1;

    int currentxp=0;

    [SerializeField]
    int maxlevel;

    [SerializeField]
    LevelUp level;

    [SerializeField]
    Movement move;

    private void Awake()
    {
        maxlevel = levelThreshold.Length - 1;
        EventsSystem.OnGetXpEvent += GetXP;
    }

    private void OnDisable()
    {

        EventsSystem.OnGetXpEvent -= GetXP;
    }

    public void GetXP(int xpGet, player contr)
    {
        if (contr != move.playerControl) return;
        currentxp += xpGet;
        CheckLevel();
    }


    public void CheckLevel()
    {
        if (levelnow < maxlevel)
        {
            if (levelThreshold[levelnow - 1] < currentxp)
            {
                currentxp = 0;
                maxlevel = Math.Clamp(levelnow,levelnow,levelnow+1);
                level.Levelup();
                Debug.Log("levelUp");
            }
        }
    }
}
