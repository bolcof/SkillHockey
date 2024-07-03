using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject demoCharactorSelectPanel;
    [SerializeField] private List<Button> charactorButtonList = new List<Button>();

    [SerializeField] private Button startButton;
    [SerializeField] private PlayerInfoFrame playerInfoFrame;
    public bool hasSelected;

    public void Set(GameInfomanager.GameMode gameMode) {
        switch (gameMode) {
            case GameInfomanager.GameMode.Online:
            case GameInfomanager.GameMode.CPU:
            case GameInfomanager.GameMode.Story:
                demoCharactorSelectPanel.SetActive(true);
                break;
            case GameInfomanager.GameMode.Local:
                demoCharactorSelectPanel.SetActive(false);
                break;
        }
        startButton.gameObject.SetActive(false);
        hasSelected = false;
        foreach (var b in charactorButtonList) {
            b.interactable = true;
        }
    }

    public void ChangeSelectingChacactor(int charaId) {
        playerInfoFrame.ChangeHighlightedCharactor(charaId);
    }

    public void EnableStartButton() {
        startButton.gameObject.SetActive(true);
        hasSelected = true;
        foreach (var b in charactorButtonList) {
            b.interactable = false;
        }
    }

    public void PushStartButton() {
        ViewManager.instance.playingView.gameObject.SetActive(true);
        ViewManager.instance.playingView.Set();
        GameObjectManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}