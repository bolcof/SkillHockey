using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPaddle : MonoBehaviour {
    [SerializeField] private Vector2 xRange;  // X軸の移動範囲
    [SerializeField] private Vector2 zRange;  // Z軸の移動範囲
    void Start() {
        MoveStart();
    }

    private void MoveStart() {
        transform.DOMove(new Vector3(Random.Range(xRange.x, xRange.y), transform.position.y, (Random.Range(zRange.x, zRange.y))), Random.Range(0.3f, 0.7f))
            .OnComplete(MoveStart);
    }
}