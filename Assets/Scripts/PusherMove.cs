using UnityEngine;

public class PusherMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float pusherMoveRange = 5f;

    private Vector3 startPosition;

    void Start()
    {
        // 初期位置を記録
        startPosition = this.transform.localPosition;
    }

    void Update()
    {
        // Sin波で前後に揺れる
        float z = Mathf.Sin(Time.time * speed) * pusherMoveRange;

        // ★ 初期位置を中心に前後移動（ズレない）
        this.transform.localPosition = startPosition + new Vector3(0, 0, z);
    }
}
