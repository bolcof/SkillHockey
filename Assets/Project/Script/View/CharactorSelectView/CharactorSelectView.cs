using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject demoPlayerPanel;
    [SerializeField] private List<Button> charactorButtonList = new List<Button>();

    public void Set(GameInfomanager.GameMode gameMode) {
        switch(gameMode) {
            case GameInfomanager.GameMode.Online:
            case GameInfomanager.GameMode.CPU:
            case GameInfomanager.GameMode.Story:
                demoPlayerPanel.SetActive(true);
                break;
            case GameInfomanager.GameMode.Local:
                demoPlayerPanel.SetActive(false);
                break;
        }
    }

    public void TestGoPlay() {
        ViewManager.instance.playingView.gameObject.SetActive(true);
        ViewManager.instance.playingView.Set();
        GameObjectManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}