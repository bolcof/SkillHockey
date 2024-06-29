using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorIcon : MonoBehaviour {
    [SerializeField] private List<GameObject> charactorImages = new List<GameObject>();

    public void Set(int charactorId) {
        foreach(var ch in charactorImages) {
            ch.gameObject.SetActive(false);
        }
        charactorImages[charactorId].SetActive(true);
    }
}