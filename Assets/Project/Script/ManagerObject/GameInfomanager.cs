using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoManager : MonoBehaviour {
    public static GameInfoManager instance;

    public int currentSelectCharactorId = -1;
    public List<SkillData> currentSkillData = new List<SkillData>();

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
        currentSkillData.Clear();
        currentSkillData.Add(DataHolder.instance.skillDatas[DataHolder.instance.charactors[charaId].SkillIds[0]]);
        currentSkillData.Add(DataHolder.instance.skillDatas[DataHolder.instance.charactors[charaId].SkillIds[1]]);
        currentSkillData.Add(DataHolder.instance.skillDatas[DataHolder.instance.charactors[charaId].SkillIds[2]]);
        ViewManager.instance.charactorSelectView.GoPlaying();
    }

    public void ResetWorld() {
        LifeManager.instance.Reset();
        currentSelectCharactorId = -1;
        enemyCharactorId = -1;
    }
}