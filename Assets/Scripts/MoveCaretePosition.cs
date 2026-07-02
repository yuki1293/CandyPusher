using System.Data;
using UnityEngine;

public class MoveCaretePosition : MonoBehaviour
{
    //自身の初期位置を保持
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         //　Sin波の動き
        float x = Mathf.Sin(Time.time * 1f)*2f;
        // Sin波の動きをX軸方向に反映させる
        this.transform.position = startPosition + new Vector3(x, 0, 0);
    }
}
