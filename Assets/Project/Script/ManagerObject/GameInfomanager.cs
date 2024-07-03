using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfomanager : MonoBehaviour {
    public static GameInfomanager instance;

    public int currentSelectCharactorId = -1;
    public GameMode currentGameMode;

    public enum GameMode {
        Local,
        Online,
        CPU,
        Story
    }

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void DecideCharactor(int charaId) {
        currentSelectCharactorId = charaId;
        ViewManager.instance.charactorSelectView.EnableStartButton();
    }
}