using UnityEngine;

public class PlayerManager : Manager
{
    public GameObject Player { get; private set; }

    public void SetPlayer(GameObject player)
    {
        Player = player;
    }
}
