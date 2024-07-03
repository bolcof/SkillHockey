using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoFrame : MonoBehaviour {
    [System.Serializable]
    public struct PlayerInfo {
        public Sprite image;
        public string name;
    };

    public List<PlayerInfo> playerInfos = new List<PlayerInfo>();

    [SerializeField] private Image currentImage;
    [SerializeField] private TextMeshProUGUI currentName;

    public void ChangeHighlightedCharactor(int id) {
        currentImage.sprite = playerInfos[id].image;
        currentName.text = playerInfos[id].name;
    }
}