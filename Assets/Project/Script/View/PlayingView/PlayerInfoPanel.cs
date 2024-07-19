using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanel : MonoBehaviour {
    [SerializeField] private Image CharactorImage;
    [SerializeField] private List<Sprite> charactorSprites = new List<Sprite>();
    [SerializeField] private List<GameObject> lifeCountLabels = new List<GameObject>();
    [SerializeField] private Image guage;
    [SerializeField] private TextMeshProUGUI guageLevel;

    public void Set(int charactorId) {
        CharactorImage.sprite = charactorSprites[charactorId];
        foreach(var life in lifeCountLabels) {
            life.SetActive(false);
        }
        lifeCountLabels[LifeManager.instance.myDefaultLife].SetActive(true);
    }

    public void LifeChange(int life) {
        foreach (var l in lifeCountLabels) {
            l.SetActive(false);
        }
        lifeCountLabels[life].SetActive(true);
    }

    public void SetGuage() {
        //TODO:SetGuage
    }
}