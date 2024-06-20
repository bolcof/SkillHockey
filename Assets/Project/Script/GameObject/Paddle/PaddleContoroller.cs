using UnityEngine;

public class PaddleController : MonoBehaviour {
    public Camera mainCamera;  // メインカメラの参照
    public float paddleHeight;  // パドルの高さ
    public Vector2 xRange = new Vector2(-6.25f, 6.25f);  // X軸の移動範囲
    public Vector2 zRange = new Vector2(-12.5f, -0.6f);  // Z軸の移動範囲

    private void Awake() {
        paddleHeight = transform.localScale.y;
    }

    void Update() {
        // マウスの位置を取得
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            // マウスの位置をXZ平面に投影
            Vector3 targetPosition = new Vector3(hit.point.x, paddleHeight, hit.point.z);

            // X軸の範囲内に制限
            targetPosition.x = Mathf.Clamp(targetPosition.x, xRange.x, xRange.y);

            // Z軸の範囲内に制限
            targetPosition.z = Mathf.Clamp(targetPosition.z, zRange.x, zRange.y);

            // パドルの位置を更新
            transform.position = targetPosition;
        }
    }
}