using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayingView : MonoBehaviour {
    public TextMeshProUGUI testLifeLabel;

    public void Set() {
        testLifeLabel.text = LifeManager.instance.myLife.ToString() + " - " + LifeManager.instance.enemyLife.ToString();
    }
}