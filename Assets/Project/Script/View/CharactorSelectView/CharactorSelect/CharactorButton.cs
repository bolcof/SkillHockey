using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharactorButton : MonoBehaviour {
    [SerializeField] private int charaId;
    [SerializeField] private bool isAvailable;

    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private List<Sprite> charactorIcons = new List<Sprite>();

    [SerializeField] private Image iconObj;
    public GameObject highlight;

    public void Set() {
        if (isAvailable) {
            iconObj.sprite = charactorIcons[charaId];
        }
        highlight.SetActive(false);
    }

    public void HoverCursor() {
        if (isAvailable) {
            ViewManager.instance.charactorSelectView.ChangeSelectingChacactor(charaId);
        }
    }

    public void PushButton() {
        if (isAvailable) {
            GameInfoManager.instance.DecideCharactor(charaId);
        }
    }
}