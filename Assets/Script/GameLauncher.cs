using Fusion;
using UnityEngine;

public class GameLauncher : MonoBehaviour {
    [SerializeField]
    private NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunner;

    private async void Start() {
        networkRunner = Instantiate(networkRunnerPrefab);
        var result = await networkRunner.StartGame(new StartGameArgs {
            GameMode = GameMode.Shared,
            SceneManager = networkRunner.GetComponent<NetworkSceneManagerDefault>()
        });

        if (result.Ok) {
            Debug.Log("ê¨å˜ÅI");
        } else {
            Debug.Log("é∏îsÅI");
        }
    }
}