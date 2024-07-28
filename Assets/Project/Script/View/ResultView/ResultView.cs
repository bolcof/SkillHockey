using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private Transform winnerCharaRoot, winnerLabelRoot, loserCharaRoot, loserLabelRoot;
    [SerializeField] private List<GameObject> winnerImageObjects, loserImageObjects;
    [SerializeField] private TextMeshProUGUI winnerOperatorLabel, loserOperatorLabel;
    [SerializeField] private GameObject titleButton;
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

        Appear();
    }

    public void Appear() {
        //winner chara object
        float defaultValue01 = winnerCharaRoot.position.x;
        winnerCharaRoot.Translate(new Vector3(1920.0f, 0.0f, 0.0f));
        winnerCharaRoot.DOMoveX(defaultValue01, 0.2f).SetDelay(1.0f).SetEase(Ease.OutElastic);

        //winner label object
        float defaultValue02 = winnerLabelRoot.position.x;
        winnerLabelRoot.Translate(new Vector3(-1920.0f, 0.0f, 0.0f));
        winnerLabelRoot.DOMoveX(defaultValue02, 0.3f).SetDelay(1.15f).SetEase(Ease.OutElastic);

        //loser charaObject
        float defaultValue03 = loserCharaRoot.position.y;
        loserCharaRoot.Translate(new Vector3(0.0f, -1080.0f, 0.0f));
        loserCharaRoot.DOMoveY(defaultValue03, 0.2f).SetDelay(1.45f).SetEase(Ease.OutElastic);

        //loser charaObject
        float defaultValue04 = loserLabelRoot.position.y;
        loserLabelRoot.Translate(new Vector3(0.0f, -1080.0f, 0.0f));
        loserLabelRoot.DOMoveY(defaultValue04, 0.3f).SetDelay(1.6f).SetEase(Ease.OutElastic);

        //Title Button
        titleButton.gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        titleButton.gameObject.GetComponent<Button>().enabled = false;
        titleButton.gameObject.GetComponent<Image>().DOFade(1.0f, 0.15f).SetDelay(3.65f).OnComplete(() => titleButton.gameObject.GetComponent<Button>().enabled = true);
    }

    public void PushTitle() {
        ViewManager.instance.titleView.gameObject.SetActive(true);
        gameObject.SetActive(false);

        GameInfoManager.instance.ResetWorld();
        GameObjectManager.instance.ResetWorld();
    }
}
