using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject demoCharactorSelectPanel;
    [SerializeField] private List<CharactorButton> charactorButtonList = new List<CharactorButton>();

    [SerializeField] private Button startButton;
    [SerializeField] private CharactorSelect_PlayerInfoFrame playerInfoFrame;
    public bool hasSelected;

    public void Set(GameInfoManager.GameMode gameMode) {
        switch (gameMode) {
            case GameInfoManager.GameMode.Online:
            case GameInfoManager.GameMode.CPU:
            case GameInfoManager.GameMode.Story:
                demoCharactorSelectPanel.SetActive(true);
                break;
            case GameInfoManager.GameMode.Local:
                demoCharactorSelectPanel.SetActive(false);
                break;
        }
        startButton.gameObject.SetActive(false);
        hasSelected = false;
    }

    public void ChangeSelectingChacactor(int charaId) {
        playerInfoFrame.ChangeHighlightedCharactor(charaId);
        foreach (var cb in charactorButtonList) {
            cb.highlight.SetActive(false);
        }
        charactorButtonList[charaId].highlight.SetActive(true);
    }

    public void EnableStartButton() {
        startButton.gameObject.SetActive(true);
        hasSelected = true;
    }

    public void PushStartButton() {
        ViewManager.instance.playingView.gameObject.SetActive(true);
        ViewManager.instance.playingView.Set();
        CommandManager.instance.SetFirst();
        GameObjectManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}