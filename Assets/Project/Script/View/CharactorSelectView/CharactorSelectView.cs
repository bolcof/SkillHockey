using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelectView : MonoBehaviour {
    public GameObject onePlayerPanel, twoPlayerPanel;
    [SerializeField] private List<Button> charactorButtonList = new List<Button>();

    public void Set(PlayerSetting.GameMode gameMode) {
        switch(gameMode) {
            case PlayerSetting.GameMode.Online:
            case PlayerSetting.GameMode.CPU:
            case PlayerSetting.GameMode.Story:
                onePlayerPanel.SetActive(true);
                twoPlayerPanel.SetActive(false);
                break;
            case PlayerSetting.GameMode.Local:
                onePlayerPanel.SetActive(false);
                twoPlayerPanel.SetActive(true);
                break;
        }
    }

    public void TestGoPlay() {
        ViewManager.instance.playingView.gameObject.SetActive(true);
        ViewManager.instance.playingView.Set();
        GameManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}