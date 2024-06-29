using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfomanager : MonoBehaviour {
    public static GameInfomanager instance;

    public enum GameMode {
        Local,
        Online,
        CPU,
        Story
    }

    public GameMode currentGameMode;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}