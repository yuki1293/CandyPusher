using UnityEngine;

public class PusherMove : MonoBehaviour
{
    public float speed = 1f;
    public float pusherMoveRange = 10f;
    private Vector3 startPosition;
    private Rigidbody rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = this.transform.localPosition;
        // 自身に付いているRigidbodyコンポーネントを取得して、変数rbに入れる
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.Sin(Time.time * speed) * pusherMoveRange;
        // 自身のローカル座標の位置を 最初の位置情報に Z(Sin波の変動値)を加算して返す
        //this.transform.localPosition = startPosition + new Vector3(0,0,z);
        rb.linearVelocity = new Vector3(0, 0, z);
    }
}
