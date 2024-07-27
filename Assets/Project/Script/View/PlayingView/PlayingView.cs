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
    [SerializeField] private SkillGuage mySkillGuage, enemySkillGuage;
    [SerializeField] private CutIn cutInElements;

    public void Set() {
        myPlayerInfo.Set(GameInfoManager.instance.currentSelectCharactorId);

        //TODO: tmp
        int enemyCharaId = 1 - GameInfoManager.instance.currentSelectCharactorId;
        GameInfoManager.instance.enemyCharactorId = enemyCharaId;

        enemyPlayerInfo.Set(enemyCharaId);
        for (int i = 0; i < skillGuides.Count; i++) {
            skillGuides[i].Set(DataHolder.instance.charactors[GameInfoManager.instance.currentSelectCharactorId].SkillIds[i]);
        }

        mySkillGuage.SetFirst();
        enemySkillGuage.SetFirst();

        cutInElements.DisableElements();
    }

    public void setTime(float currentTime) {
        timeLimit.Set(currentTime);
    }

    public void SetWhiteGuage(bool isMyPoint, float point) {
        if (isMyPoint) {
            mySkillGuage.SetWhite(point);
        } else {
            enemySkillGuage.SetWhite(point);
        }
    }

    public void ApplyGuage(bool isMyPoint, float point) {
        if (isMyPoint) {
            mySkillGuage.SetFill(point);
        } else {
            enemySkillGuage.SetFill(point);
        }
    }

    public void CastSkill(bool isPlayer, int level, float gameSpeed) {
        cutInElements.CastSkill(isPlayer, level, gameSpeed);
    }
}