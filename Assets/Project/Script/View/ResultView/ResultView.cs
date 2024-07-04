using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private List<GameObject> winnerImageObject, loserImageObject;
    [SerializeField] private TextMeshProUGUI operatorLabel, winnerCharaLabel, resultLabel;

    public void Set(int playerCharaId, int enemyCharaId, bool hasPlayerWin) {
        foreach(var wio in winnerImageObject) {
            wio.SetActive(false);
        }
        foreach(var lio in loserImageObject) {
            lio.SetActive(false);
        }

        if (hasPlayerWin) {
            operatorLabel.text = "Player";
            winnerImageObject[playerCharaId].SetActive(true);
            loserImageObject[enemyCharaId].SetActive(true);
            winnerCharaLabel.text = DataHolder.instance.charactors[playerCharaId].name;
        } else {
            operatorLabel.text = "CPU";
            winnerImageObject[enemyCharaId].SetActive(true);
            loserImageObject[playerCharaId].SetActive(true);
            winnerCharaLabel.text = DataHolder.instance.charactors[enemyCharaId].name;
        }

    }

    public void Appear() {

    }

    public void PushTitle() {
        ViewManager.instance.titleView.gameObject.SetActive(true);
        gameObject.SetActive(false);

        GameInfoManager.instance.ResetWorld();
        GameObjectManager.instance.ResetWorld();
    }
}
