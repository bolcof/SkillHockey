using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_PlayerInfo : MonoBehaviour {
    [SerializeField] private List<GameObject> charactorSprites = new List<GameObject>();
    [SerializeField] private List<GameObject> lifeMarkers = new List<GameObject>();
    [SerializeField] private Image guage;
    [SerializeField] private TextMeshProUGUI guageLevel;

    public void Set() {
        foreach (var obj in charactorSprites) {
            obj.SetActive(false);
        }
        charactorSprites[GameInfomanager.instance.currentSelectCharactorId].SetActive(true);

        foreach(var life in lifeMarkers) {
            life.SetActive(true);
        }
    }

    public void LifeChange(int life) {
        foreach (var l in lifeMarkers) {
            l.SetActive(false);
        }
        for (int i = 0; i < life; i++) {
            lifeMarkers[i].SetActive(true);
        }
    }

    public void SetGuage() {

    }

}