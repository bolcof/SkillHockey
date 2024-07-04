using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayingView : MonoBehaviour {
    public TextMeshProUGUI timeLabel;
    public Playing_PlayerInfo myPlayerInfo, enemyPlayerInfo;

    public void Set() {
        myPlayerInfo.Set(GameInfoManager.instance.currentSelectCharactorId);

        //TODO: tmp
        int enemyCharaId = 1 - GameInfoManager.instance.currentSelectCharactorId;
        GameInfoManager.instance.enemyCharactorId = enemyCharaId;
        
        enemyPlayerInfo.Set(enemyCharaId);
    }
}