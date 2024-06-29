using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGuage : MonoBehaviour {
    [SerializeField] private List<Image> cells;
    private int maxLife, currentLife;

    public void Set() {
        maxLife = cells.Count;
        currentLife = maxLife;
    }

    public void Damage(int damage) {
        for (int i = 0; i < damage; i++) {
            if (currentLife > 0) {
                cells[currentLife - 1].gameObject.SetActive(false);
                currentLife--;
            }
        }
    }
}