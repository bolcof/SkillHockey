using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharactorButton : MonoBehaviour {
    [SerializeField] int charaId;

    public void HoverCursor() {
        ViewManager.instance.charactorSelectView.ChangeSelectingChacactor(charaId);
        Debug.Log("hovered " + charaId.ToString());
    }

    public void PushButton() {
        CharactorSelectManager.instance.DecideCharactor(charaId);
    }
}