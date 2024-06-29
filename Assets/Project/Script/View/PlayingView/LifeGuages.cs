using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGuages : MonoBehaviour {
    [SerializeField] private List<GameObject> guages = new List<GameObject>();

    public void Set(int maxLife) {
        foreach(var g in guages) {
            g.SetActive(false);
        }
        guages[0].SetActive(true);
        guages[0].GetComponent<LifeGuage>().Set();
    }
}