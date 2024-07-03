using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharactorButton : MonoBehaviour {
    [SerializeField] int charaId;
    [SerializeField] bool isAvailable;

    public void HoverCursor() {
        if (isAvailable) {
            ViewManager.instance.charactorSelectView.ChangeSelectingChacactor(charaId);
        }
    }

    public void PushButton() {
        if (isAvailable) {
            GameInfomanager.instance.DecideCharactor(charaId);
        }
    }
}