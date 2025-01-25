using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour
{
    public Transform[] SpawnLocation ;

    private int spawnLocation = -1 ;

    public int brbrl = 0;

    public Transform GetLocation()
    {
        if (spawnLocation < 0)
        {
            spawnLocation = Random.Range(0, SpawnLocation.Length);
            return SpawnLocation[spawnLocation];
        }
        else
        {
            var number = Random.Range(0, SpawnLocation.Length);
            while (number == spawnLocation)
            {
                number = Random.Range(0, SpawnLocation.Length);
            }
            spawnLocation = number;
            return SpawnLocation[spawnLocation];
        }
    }
}
