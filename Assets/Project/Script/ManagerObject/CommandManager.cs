using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    public static CommandManager instance;

    public bool canInput, enemyTouched;
    public int maxKeyInput;
    public List<int> inputedAllows = new List<int>();

    public float mySkillPoint;
    // TODO:demo
    public float enemySkillPoint;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        inputedAllows.Clear();
    }

    public void SetFirst() {
        mySkillPoint = 0;
        enemySkillPoint = 0;
        canInput = false;
        ResetKeys();
    }

    public void PackGoaled() {
        canInput = false;
        ResetKeys();
    }

    private void Update() {
        if (canInput && inputedAllows.Count < maxKeyInput) {
            if (Input.GetKeyDown(KeyCode.W)) {
                InputKey(0);
            } else if (Input.GetKeyDown(KeyCode.S)) {
                InputKey(1);
            } else if (Input.GetKeyDown(KeyCode.A)) {
                InputKey(2);
            } else if (Input.GetKeyDown(KeyCode.D)) {
                InputKey(3);
            }
        }
    }

    private void InputKey(int i) {

        ViewManager.instance.playingView.commandLinePanel.AddAllow(inputedAllows.Count, i);
        inputedAllows.Add(i);
    }

    private void ResetKeys() {
        inputedAllows.Clear();
        ViewManager.instance.playingView.commandLinePanel.ResetView();
    }

    public void TouchMyPaddle() {
        canInput = true;
        if (enemyTouched) {
            SearchSkill();
        }
        ResetKeys();
        enemyTouched = false;
    }

    public void TouchMyWall() {
        canInput = false;
        ResetKeys();
    }

    public int SearchSkill() {

        if (CompareLastElements(GameInfoManager.instance.currentSkillData[2].command, inputedAllows)) {
            Debug.Log("Skill Lv3");
        } else if (CompareLastElements(GameInfoManager.instance.currentSkillData[1].command, inputedAllows)) {
            Debug.Log("Skill Lv2");
        } else if (CompareLastElements(GameInfoManager.instance.currentSkillData[0].command, inputedAllows)) {
            Debug.Log("Skill Lv1");
        }

        return -1;
    }
    private static bool CompareLastElements(List<int> Command, List<int> Inputed) {
        int n = Command.Count;

        // InputedがCommandより要素数が少ない場合、比較できないためFalseを返す
        if (Inputed.Count < n) {
            return false;
        }

        // Inputedの最後のn個の要素をCommandと比較する
        for (int i = 0; i < n; i++) {
            if (Command[i] != Inputed[Inputed.Count - n + i]) {
                return false;
            }
        }

        return true;
    }
}