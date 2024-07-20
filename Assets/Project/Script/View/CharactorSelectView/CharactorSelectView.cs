using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject demoCharactorSelectPanel;
    [SerializeField] private List<CharactorButton> charactorButtonList = new List<CharactorButton>();
    [SerializeField] private CharactorSelect_PlayerInfoFrame playerInfoFrame;
    [SerializeField] private List<SkillInfo> skillInfos = new List<SkillInfo>();

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
    }

    public void ChangeSelectingChacactor(int charaId) {
        playerInfoFrame.ChangeHighlightedCharactor(charaId);
        foreach (var cb in charactorButtonList) {
            cb.highlight.SetActive(false);
        }
        charactorButtonList[charaId].highlight.SetActive(true);

        for (int i = 0; i < 3; i++) {
            skillInfos[i].Set(DataHolder.instance.charactors[charaId].SkillIds[i]);
        }
    }

    public void GoPlaying() {
        ViewManager.instance.playingView.gameObject.SetActive(true);
        ViewManager.instance.playingView.Set();
        CommandManager.instance.SetFirst();
        GameObjectManager.instance.GameStart();
        gameObject.SetActive(false);
    }

    public void BackTitle() {
        ViewManager.instance.titleView.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}