using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    private List<bool> isActing = new List<bool>();
    private List<float> remainTime = new List<float>();

    public void Start() {
        Reset();
    }

    public void Reset() {
        isActing.Clear();
        remainTime.Clear();
        for (int i = 0; i < DataHolder.instance.skillDatas.Count; i++) {
            isActing.Add(false);
            remainTime.Add(0.0f);
        }
    }

    public void CastSkill(int skillId) {
        switch (skillId) {
            case 0:
                CastSkill_000();
                break;
            case 1:
                CastSkill_001();
                break;
            case 2:
                CastSkill_002();
                break;
            case 3:
                CastSkill_003();
                break;
            case 4:
                CastSkill_004();
                break;
            case 5:
                CastSkill_005();
                break;
            default:
                break;
        }
    }

    private void FixedUpdate() {

    }

    //Giant Grip
    public void CastSkill_000() {
        remainTime[0] = 15.0f;
    }

    //Blitz Drive
    public void CastSkill_001() {

    }

    //Assault Fuly
    public void CastSkill_002() {

    }

    //Twin Shade
    public void CastSkill_003() {

    }

    //Shadow Veil
    public void CastSkill_004() {

    }

    //Mystery Pack
    public void CastSkill_005() {

    }
}