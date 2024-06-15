using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined {
    public GameObject PlayerPrefab;
    public GameObject PhysxBall;

    public void PlayerJoined(PlayerRef player) {
        if (player == Runner.LocalPlayer) {
            Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            for(int i=0;i<10;i++) {
                Runner.Spawn(PhysxBall, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(3.5f, 4.5f), Random.Range(-0.5f, 0.5f)), Quaternion.identity);
            }
        }
    }
}