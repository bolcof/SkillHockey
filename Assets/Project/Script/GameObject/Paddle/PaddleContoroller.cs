using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour {
    private Rigidbody rb;

    public float moveSpeed = 5f; // オブジェクトの動きの速さ
    public Vector2 xRange = new Vector2(-62.5f, 62.5f);  // X軸の移動範囲
    public Vector2 zRange = new Vector2(-125f, -6f);  // Z軸の移動範囲
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


        // Rigidbodyの位置をマウスの位置に追従させる
        targetPosition = new Vector3();
        targetPosition.x = Remap(mouseScreenPosition.x, 0, screenWidth, xRange.x * 1.2f, xRange.y * 1.2f);
        targetPosition.x = Mathf.Clamp(targetPosition.x, xRange.x, xRange.y);
        targetPosition.y = transform.position.y;
        targetPosition.z = Remap(mouseScreenPosition.y, 0, screenHeight, zRange.x * 1.2f, zRange.y * 1.2f);
        targetPosition.z = Mathf.Clamp(targetPosition.z, zRange.x, zRange.y);

        // 直接位置を更新するのではなく、スムーズに移動するように力を加える
        //Vector3 direction = (targetPosition - transform.position).normalized;
        //rb.MovePosition(direction * moveSpeed);

        transform.position = targetPosition;
    }
    public float Remap(float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}