using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedInfo : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI lockedMessage;

    public void Set(int charaId) {
        lockedMessage.text = DataHolder.instance.charactors[charaId].lockedMessage;
    }
}