using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    public static CommandManager instance;

    public bool canInput, enemyTouched;
    public int maxKeyInput;
    public List<int> inputedAllows = new List<int>();

    public float mySkillGuage;
    // TODO:demo
    public float enemySkillGuage;

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
        mySkillGuage = 0;
        enemySkillGuage = 0;
        canInput = false;
        ResetKeys();
    }

    public void PackGoaled() {
        canInput = false;
        ResetKeys();
    }

    private void Update() {
        if (canInput && inputedAllows.Count < maxKeyInput) {
            if(Input.GetKeyDown(KeyCode.W)) {
                InputKey(0);
            }else if(Input.GetKeyDown(KeyCode.S)) {
                InputKey(1);
            } else if(Input.GetKeyDown(KeyCode.A)) {
                InputKey(2);
            } else if(Input.GetKeyDown(KeyCode.D)) {
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
        Debug.Log("SearchSkill");
        return -1;
    }
}