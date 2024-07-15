using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoManager : MonoBehaviour {
    public static GameInfoManager instance;

    public int currentSelectCharactorId = -1;
    public int currentSkillId_Lv1 = -1;
    public int currentSkillId_Lv2 = -1;
    public int currentSkillId_Lv3 = -1;

    public int enemyCharactorId = -1;
    public GameMode currentGameMode;

    public enum GameMode {
        Local,
        Online,
        CPU,
        Story
    }

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void DecideCharactor(int charaId) {
        currentSelectCharactorId = charaId;
        currentSkillId_Lv1 = DataHolder.instance.charactors[charaId].SkillIds[0];
        currentSkillId_Lv2 = DataHolder.instance.charactors[charaId].SkillIds[1];
        currentSkillId_Lv3 = DataHolder.instance.charactors[charaId].SkillIds[2];
        ViewManager.instance.charactorSelectView.EnableStartButton();
    }

    public void ResetWorld() {
        LifeManager.instance.Reset();
        currentSelectCharactorId = -1;
        enemyCharactorId = -1;
    }
}