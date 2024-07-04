using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private List<GameObject> winnerImageObject, loserImageObject;
    [SerializeField] private TextMeshProUGUI operatorLabel, winnerLabel, resultLabel;

    public void Set(int winnerCharaId, int loserCharaId) {

    }

    public void Appear() {

    }

    public void PushTitle() {
        ViewManager.instance.titleView.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
