using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPaddle : MonoBehaviour {
    private Vector2 xRange = new Vector2(-6.25f, 6.25f);  // X軸の移動範囲
    private Vector2 zRange = new Vector2(0.6f, 12.5f);  // Z軸の移動範囲
    void Start() {
        MoveStart();
    }

    private void MoveStart() {
        transform.DOMove(new Vector3(Random.Range(xRange.x, xRange.y), transform.position.y, (Random.Range(zRange.x, zRange.y))), Random.Range(0.3f, 0.7f))
            .OnComplete(MoveStart);
    }
}