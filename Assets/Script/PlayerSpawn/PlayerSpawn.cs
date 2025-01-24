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
            int loop = i;
            var player = Instantiate(Player, Location.GetLocation().position, Quaternion.identity);
            if (loop == 0)
            {
                player.GetComponent<Movement>().ChangeControl(global::player.one);
            }
            else
            {
                player.GetComponent<Movement>().ChangeControl(global::player.two);
            }
            SplitMonitor.RegisterPlayer(player.transform);
            loop++;
        }

        SplitMonitor.SetCamera();
    }
}
