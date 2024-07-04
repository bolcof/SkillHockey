using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactorSelect_PlayerInfoFrame : MonoBehaviour {

    public List<CharactorData> playerInfos = new List<CharactorData>();

    [SerializeField] private Image currentImage;
    [SerializeField] private TextMeshProUGUI currentName;

    public void ChangeHighlightedCharactor(int id) {
        currentImage.sprite = DataHolder.instance.charactors[id].selectingImage;
        currentName.text = DataHolder.instance.charactors[id].name;
    }
}