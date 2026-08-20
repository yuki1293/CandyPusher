using UnityEngine;

public class EventManager : MonoBehaviour
{
    // ランダムイベントを開始する
    public void StartRandomEvent()
    {
        // 0～2の数字をランダムで選ぶ
        int random = Random.Range(0, 3);

        // 0だった場合
        if (random == 0)
        {
            // スコアアップ
            ScoreUp();
        }

        // 1だった場合
        else if (random == 1)
        {
            // 押し出す力アップ
            PushPowerUp();
        }

        // それ以外（2）の場合
        else
        {
            // コインボーナス
            CoinUp();
        }
    }

    // スコアアップの処理
    void ScoreUp()
    {
        Debug.Log("スコアアップ！");
    }

    // 押し出す力アップの処理
    void PushPowerUp()
    {
        Debug.Log("押し出す力アップ！");
    }

    // コインボーナスの処理
    void CoinUp()
    {
        Debug.Log("コインボーナス！");
    }
}