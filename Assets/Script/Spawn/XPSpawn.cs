using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class XPSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject xp;

    int XPget;

    List<PickUp> bb = new();

    private void Awake()
    {
        EventsSystem.OnSpawnXpEvent += SpawnXp;
    }

    private void OnDestroy()
    {
        EventsSystem.OnSpawnXpEvent -= SpawnXp;
    }

    private void SpawnXp(Transform position, int xp)
    {
        if (bb.Where(x => x.gameObject.activeInHierarchy).Count() == 0)
        {
            var obj = Instantiate(this.xp, position.position,Quaternion.identity).GetComponent<PickUp>();
            obj.XP = xp;
            bb.Add(obj);
        }
        else
        {
            var obj = bb.Find(x => x.gameObject.activeInHierarchy);
            obj.XP = xp;
            obj.transform.position = position.position;
        }
    }

    
}
