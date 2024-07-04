using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayingView : MonoBehaviour {
    public TextMeshProUGUI timeLabel;
    public Main_PlayerInfo myPlayerInfo, enemyPlayerInfo;

    public void Set() {
        myPlayerInfo.Set();
        enemyPlayerInfo.Set();
    }
}