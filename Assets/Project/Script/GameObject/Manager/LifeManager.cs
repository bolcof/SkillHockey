using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {
    public static LifeManager instance;
    public int myLife, enemyLife;
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayerDamage() {
        myLife--;
        GameManager.instance.ResetPack();
        ChangeLabel();
    }

    public void EnemyDamage() {
        enemyLife--;
        GameManager.instance.ResetPack();
        ChangeLabel();
    }

    private void ChangeLabel() {
        string labelTest = myLife.ToString() + " - " + enemyLife.ToString();
        ViewManager.instance.playingView.testLifeLabel.text = labelTest;
    }
}
