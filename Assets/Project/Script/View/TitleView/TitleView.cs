using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleView : MonoBehaviour {

    [SerializeField] private List<float> highlightPositions = new List<float>();
    [SerializeField] private Image highlightBar;

    public void Start() {
        Debug.Log(highlightBar.GetComponent<RectTransform>().position);
        highlightBar.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void PushStart() {
        highlightBar.DOFade(0.0f, 0.2f);
        TransitCharactorSelectView();
    }

    private void TransitCharactorSelectView() {
        ViewManager.instance.charactorSelectView.gameObject.SetActive(true);
        ViewManager.instance.charactorSelectView.Set(GameInfoManager.GameMode.CPU);
        gameObject.SetActive(false);

        GameInfoManager.instance.currentGameMode = GameInfoManager.GameMode.CPU;
    }

    public void HoverButton(int id) {
        highlightBar.DOFade(1.0f, 0.225f);
        highlightBar.GetComponent<RectTransform>().DOMoveY(highlightPositions[id], 0.125f);
    }
}