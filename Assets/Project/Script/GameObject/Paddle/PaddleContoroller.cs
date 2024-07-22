using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    private Rigidbody rb;

    [SerializeField] private Vector2 xRange; // X軸の移動範囲
    [SerializeField] private Vector2 zRange;  // Z軸の移動範囲
    public Vector3 targetPosition;

    private int screenWidth, screenHeight;

    void Start() {
        rb = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    void Update() {
        MoveWithMouse();
    }

    void MoveWithMouse() {
        // マウスのスクリーン座標を取得
        Vector3 mouseScreenPosition = Input.mousePosition;

        // X軸の位置を計算
        float targetX = Remap(mouseScreenPosition.x, 0, screenWidth, xRange.x, xRange.y);
        // Z軸の位置を計算
        float targetZ = Remap(mouseScreenPosition.y, 0, screenHeight, zRange.x, zRange.y);

        // 範囲内に制限
        targetX = Mathf.Clamp(targetX, xRange.x, xRange.y);
        targetZ = Mathf.Clamp(targetZ, zRange.x, zRange.y);

        // targetPositionを更新
        targetPosition = new Vector3(targetX, transform.position.y, targetZ);

        // Rigidbodyの位置を更新
        rb.MovePosition(targetPosition);
    }

    public float Remap(float value, float from1, float to1, float from2, float to2) {
        float returnVal = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        return returnVal;
    }
}