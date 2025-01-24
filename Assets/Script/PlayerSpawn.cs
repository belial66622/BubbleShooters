using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    PlayerSpawnLocation Location;

    [SerializeField]
    CameraSplitMonitor SplitMonitor;

    int numberOfPlayer = 0;
    private void Awake()
    {
        numberOfPlayer = GetComponent<PlayerNumber>().playerSpawn;

        for (int i = 0; i < numberOfPlayer; i++)
        {
            var player = Instantiate(Player, Location.GetLocation().position, Quaternion.identity);
            SplitMonitor.RegisterPlayer(player.transform);
        }

        SplitMonitor.SetCamera();
    }
}
