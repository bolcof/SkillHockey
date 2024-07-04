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
        GameObjectManager.instance.ResetPack();
        ViewManager.instance.playingView.myPlayerInfo.LifeChange(myLife);
        if (myLife == 0) {
            EndGame(false);
        }
    }

    public void EnemyDamage() {
        enemyLife--;
        GameObjectManager.instance.ResetPack();
        ViewManager.instance.playingView.enemyPlayerInfo.LifeChange(enemyLife);
        if (enemyLife == 0) {
            EndGame(true);
        }
    }

    private void EndGame(bool playerWin) {
        ViewManager.instance.playingView.gameObject.SetActive(false);
        ViewManager.instance.resultView.gameObject.SetActive(true);
    }
}
