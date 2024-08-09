using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {
    public static CommandManager instance;

    // TODO:onlyCpuMode
    public int maxKeyInput;
    public List<int> inputedAllows = new List<int>();

    private bool canPlayerCommandInput, canPlayerActuateSkill;
    private bool canEnemyCommandInput, canEnemyActuateSkill;

    private bool isPlayerCharging, isEnemyCharging;
    private bool isPlayerPointActivate, isEnemyPointActivate;

    public float mySkillPoint, myChargingPoint;
    public float enemySkillPoint, enemyChargingPoint;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        inputedAllows.Clear();

        isPlayerPointActivate = false;
        isEnemyPointActivate = false;

        isPlayerCharging = false;
        isEnemyCharging = false;
    }

    public void SetFirst() {
        mySkillPoint = 0;
        enemySkillPoint = 0;
        canPlayerCommandInput = false;
        ResetKeys();
    }

    public void PackGoaled() {
        canPlayerCommandInput = false;
        ResetKeys();
        ResetWhite(true);
        ResetWhite(false);
    }

    private void Update() {
        if (canPlayerCommandInput && inputedAllows.Count < maxKeyInput) {
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

        //TODO:debug
        if (Input.GetKeyDown(KeyCode.T)) {
            ChargeWhite(true, 15);
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            ApplyWhite(true);
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
        //Player Skill
        canPlayerCommandInput = true;
        if (canPlayerActuateSkill) {
            SearchSkill();
        }
        ResetKeys();
        canPlayerActuateSkill = false;

        //Enemy Skill
        canEnemyActuateSkill = true;

        //Player Charge
        isPlayerCharging = true;
        if (isPlayerPointActivate) {
            ApplyWhite(true);
        } else {
            ResetWhite(true);
        }
        ChargeWhite(true, 5);
        isPlayerPointActivate = false;

        //Enemy Charge
        isEnemyCharging = false;
        isEnemyPointActivate = true;
    }

    public void TouchEnemyPaddle() {
        //Player Skill
        canPlayerActuateSkill = true;

        //Enemy Skill
        if (canEnemyActuateSkill) {
            EnemySkill();
        }
        canEnemyActuateSkill = false;

        //Player Charge
        isPlayerCharging = false;
        isPlayerPointActivate = true;

        //Enemy Charge
        isEnemyCharging = true;
        if (isEnemyPointActivate) {
            ApplyWhite(false);
        } else {
            ResetWhite(false);
        }
        ChargeWhite(false, 5);
        isEnemyPointActivate = false;
    }

    public void TouchMyWall() {
        //Player Skill
        ResetKeys();
        canPlayerCommandInput = false;

        //Enemy Skill
        canEnemyActuateSkill = true;

        //Player Charge
        isPlayerCharging = false;
        if (isPlayerPointActivate) {
            ApplyWhite(true);
        } else {
            ResetWhite(true);
        }
        isPlayerPointActivate = false;

        //Enemy Charge
        isEnemyPointActivate = true;
    }

    public void TouchEnemyWall() {
        //Player Skill
        canPlayerActuateSkill = true;

        //Enemy Skill

        //Player Charge
        isPlayerPointActivate = true;

        //Enemy Charge
        isEnemyCharging = false;
        if (isEnemyPointActivate) {
            ApplyWhite(false);
        } else {
            ResetWhite(false);
        }
        isEnemyPointActivate = false;
    }

    public void TouchSideWall() {
        if (isPlayerCharging) {
            ChargeWhite(true, 9);
        }
        if (isEnemyCharging) {
            ChargeWhite(false, 9);
        }
    }

    private void ChargeWhite(bool isMyPoint, float point) {
        if (isMyPoint) {
            myChargingPoint += point;
            ViewManager.instance.playingView.SetWhiteGuage(true, myChargingPoint);
        } else {
            enemyChargingPoint += point;
            ViewManager.instance.playingView.SetWhiteGuage(false, enemyChargingPoint);
        }
    }

    private void ResetWhite(bool isMyPoint) {
        if (isMyPoint) {
            myChargingPoint = 0;
            ViewManager.instance.playingView.SetWhiteGuage(true, myChargingPoint);
        } else {
            enemyChargingPoint = 0;
            ViewManager.instance.playingView.SetWhiteGuage(false, myChargingPoint);
        }
    }

    private void ApplyWhite(bool isMyPoint) {
        if (isMyPoint) {
            mySkillPoint += myChargingPoint;
            if (mySkillPoint >= 300) {
                mySkillPoint = 300;
            }
            myChargingPoint = 0;
            ViewManager.instance.playingView.ApplyGuage(true, mySkillPoint);
        } else {
            enemySkillPoint += enemyChargingPoint;
            if (enemySkillPoint >= 300) {
                enemySkillPoint = 300;
            }
            enemyChargingPoint = 0;
            ViewManager.instance.playingView.ApplyGuage(false, enemySkillPoint);
        }
    }

    private int SearchSkill() {

        List<int> currentPlayerSkillIds = DataHolder.instance.charactors[GameInfoManager.instance.currentSelectCharactorId].SkillIds;

        if (CompareLastElements(GameInfoManager.instance.currentSkillData[2].command, inputedAllows)) {
            if (mySkillPoint >= 300) {
                mySkillPoint = 0;
                ViewManager.instance.playingView.SetWhiteGuage(true, mySkillPoint);
                ViewManager.instance.playingView.CastSkill(true, 3, 0.025f);
                SkillManager.instance.CastSkill(currentPlayerSkillIds[2], true);
                HitStop(3f, 0.025f);
            }
        } else if (CompareLastElements(GameInfoManager.instance.currentSkillData[1].command, inputedAllows)) {
            if (mySkillPoint >= 200) {
                mySkillPoint -= 200;
                ViewManager.instance.playingView.SetWhiteGuage(true, mySkillPoint);
                ViewManager.instance.playingView.CastSkill(true, 2, 0.005f);
                SkillManager.instance.CastSkill(currentPlayerSkillIds[1], true);
                HitStop(2.5f, 0.005f);
            }
        } else if (CompareLastElements(GameInfoManager.instance.currentSkillData[0].command, inputedAllows)) {
            if (mySkillPoint >= 100) {
                mySkillPoint -= 100;
                ViewManager.instance.playingView.SetWhiteGuage(true, mySkillPoint);
                ViewManager.instance.playingView.CastSkill(true, 1, 0.005f);
                SkillManager.instance.CastSkill(0, true);
                HitStop(2.5f, 0.005f);
            }
        }

        return -1;
    }

    private void EnemySkill() {
        Debug.Log("enemy can put skill : " + ((int)enemySkillPoint / 100).ToString());
    }

    private void HitStop(float duration, float speed) {
        StartCoroutine(SlowCoroutine(duration, speed));
    }

    private IEnumerator SlowCoroutine(float duration, float speed) {
        Time.timeScale = speed;
        Time.fixedDeltaTime = 0.02f * speed;
        GameObjectManager.instance.playerPaddle.isSlowing = true;
        GameObjectManager.instance.enemyCpuPaddle.isSlowing = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        GameObjectManager.instance.playerPaddle.isSlowing = false;
        GameObjectManager.instance.enemyCpuPaddle.isSlowing = false;
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