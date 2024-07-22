using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayingView : MonoBehaviour {
    public TimeLimit timeLimit;
    public PlayerInfoPanel myPlayerInfo, enemyPlayerInfo;
    public CommandLinePanel commandLinePanel;
    [SerializeField] List<SkillGuide> skillGuides = new List<SkillGuide>();

    public void Set() {
        myPlayerInfo.Set(GameInfoManager.instance.currentSelectCharactorId);

        //TODO: tmp
        int enemyCharaId = 1 - GameInfoManager.instance.currentSelectCharactorId;
        GameInfoManager.instance.enemyCharactorId = enemyCharaId;

        enemyPlayerInfo.Set(enemyCharaId);
        for (int i = 0; i < skillGuides.Count; i++) {
            skillGuides[i].Set(DataHolder.instance.charactors[GameInfoManager.instance.currentSelectCharactorId].SkillIds[i]);
        }
    }

    public void setTime(float currentTime) {
        timeLimit.Set(currentTime);
    }
}