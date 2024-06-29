using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject onePlayerPanel, twoPlayerPanel;
    [SerializeField] private List<Button> charactorButtonList = new List<Button>();

    public void Set(GameInfomanager.GameMode gameMode) {
        switch(gameMode) {
            case GameInfomanager.GameMode.Online:
            case GameInfomanager.GameMode.CPU:
            case GameInfomanager.GameMode.Story:
                onePlayerPanel.SetActive(true);
                twoPlayerPanel.SetActive(false);
                break;
            case GameInfomanager.GameMode.Local:
                onePlayerPanel.SetActive(false);
                twoPlayerPanel.SetActive(true);
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