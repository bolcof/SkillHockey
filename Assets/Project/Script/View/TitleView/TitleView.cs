using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleView : MonoBehaviour {

    public void PushStart() {
        ViewManager.instance.charactorSelectView.gameObject.SetActive(true);
        ViewManager.instance.charactorSelectView.Set(GameInfoManager.GameMode.CPU);
        gameObject.SetActive(false);

        GameInfoManager.instance.currentGameMode = GameInfoManager.GameMode.CPU;
    }
}