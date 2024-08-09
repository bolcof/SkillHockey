using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    private List<bool> isActing = new List<bool>();
    private List<float> remainTime = new List<float>();

    private int skillNum;

    public void Start() {
        Reset();
    }

    public void Reset() {
        isActing.Clear();
        remainTime.Clear();
        skillNum = DataHolder.instance.skillDatas.Count;
        for (int i = 0; i < skillNum; i++) {
            isActing.Add(false);
            remainTime.Add(0.0f);
        }
    }

    public void CastSkill(int skillId, bool isPlayer) {
        switch (skillId) {
            case 0:
                CastSkill_000(isPlayer);
                break;
            case 1:
                CastSkill_001(isPlayer);
                break;
            case 2:
                CastSkill_002(isPlayer);
                break;
            case 3:
                CastSkill_003(isPlayer);
                break;
            case 4:
                CastSkill_004(isPlayer);
                break;
            case 5:
                CastSkill_005(isPlayer);
                break;
            default:
                break;
        }
    }

    private void FixedUpdate() {
        for (int i = 0; i < skillNum; i++) {
            if (isActing[i]) {
                remainTime[i] -= Time.deltaTime;
            }
        }
    }

    //Giant Grip
    public void CastSkill_000(bool isPlayer) {
        remainTime[0] = 15.0f;
    }

    //Blitz Drive
    public void CastSkill_001(bool isPlayer) {

    }

    //Assault Fuly
    public void CastSkill_002(bool isPlayer) {

    }

    //Twin Shade
    public void CastSkill_003(bool isPlayer) {

    }

    //Shadow Veil
    public void CastSkill_004(bool isPlayer) {

    }

    //Mystery Pack
    public void CastSkill_005(bool isPlayer) {

    }
}