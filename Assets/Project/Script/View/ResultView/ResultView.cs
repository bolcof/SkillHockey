using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private List<GameObject> winnerImageObjects, loserImageObjects;
    [SerializeField] private TextMeshProUGUI winnerOperatorLabel, loserOperatorLabel;
    //[SerializeField] private TextMeshProUGUI winnerCharaLabel, resultLabel;

    public void Set(int playerCharaId, int enemyCharaId, bool hasPlayerWin) {
        foreach (var wio in winnerImageObjects) {
            wio.SetActive(false);
        }
        foreach (var lio in loserImageObjects) {
            lio.SetActive(false);
        }

        if (hasPlayerWin) {
            winnerOperatorLabel.text = "Player";
            loserOperatorLabel.text = "CPU";
            winnerImageObjects[playerCharaId].SetActive(true);
            loserImageObjects[enemyCharaId].SetActive(true);
        } else {
            winnerOperatorLabel.text = "CPU";
            loserOperatorLabel.text = "Player";
            winnerImageObjects[enemyCharaId].SetActive(true);
            loserImageObjects[playerCharaId].SetActive(true);
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
