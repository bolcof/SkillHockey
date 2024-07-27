using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCpuPaddle : MonoBehaviour {
    [SerializeField] private Vector2 xRange;  // X軸の移動範囲
    [SerializeField] private Vector2 zRange;  // Z軸の移動範囲

    [SerializeField] private Vector2 gatePos, centerPos;
    [SerializeField] private float perfectLine;

    public bool isSlowing;

    public enum CpuMode {
        StopOnGate,
        StopOnCenter,
        Random,
        Perfect,
        CPU_Strong,
        CPU_Middle,
        CPU_Weak
    };

    public CpuMode currentCpuMode;

    void Start() {
        switch (currentCpuMode) {
            case CpuMode.StopOnGate:
                transform.position = new Vector3(gatePos.x, transform.position.y, gatePos.y);
                break;
            case CpuMode.StopOnCenter:
                transform.position = new Vector3(centerPos.x, transform.position.y, centerPos.y);
                break;
            case CpuMode.Random:
                RandomMoveStart();
                break;
        }
        isSlowing = false;
    }

    private void Update() {
        if (!isSlowing) {
            switch (currentCpuMode) {
                case CpuMode.Perfect:
                    if (GameObjectManager.instance.currentPack != null) {
                        transform.position = new Vector3(GameObjectManager.instance.currentPack.transform.position.x, transform.position.y, perfectLine);
                    }
                    break;
            }
        }
    }

    private void ChangeMode(CpuMode nextMode) {
        currentCpuMode = nextMode;

        switch (currentCpuMode) {
            case CpuMode.StopOnGate:
                transform.position = new Vector3(gatePos.x, transform.position.y, gatePos.y);
                break;
            case CpuMode.StopOnCenter:
                transform.position = new Vector3(centerPos.x, transform.position.y, centerPos.y);
                break;
            case CpuMode.Random:
                RandomMoveStart();
                break;
        }
    }

    private void RandomMoveStart() {
        transform.DOMove(new Vector3(Random.Range(xRange.x, xRange.y), transform.position.y, (Random.Range(zRange.x, zRange.y))), Random.Range(0.3f, 0.7f))
            .OnComplete(RandomMoveStart);
    }
}