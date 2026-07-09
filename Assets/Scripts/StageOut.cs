using UnityEngine;
using TMPro;
using System;

public class StageOut : MonoBehaviour
{
    private int Score = 0;
    public TextMeshProUGUI ScoreText;

    // 来週の頭(一限)に適当に選んだ3人を当てる予定
    // 要件定義：StageOutクラスの中に変数 Scoreを作成、オブジェクトがすり抜けたらScoreを1加算する
    // 1. StageOutクラスの中に変数 Scoreを作成
    // 2. 変数 Score は int型 かつ private であること
    // 3. オブジェクトがすり抜けたら(OnTriggerEnterが呼ばれたら)変数 Scoreに1を加算する
    // 4. 加算後の変数 ScoreをDebug.Logでコンソール上に出力する

    public AudioManager audioManager;
    // このコードがアタッチされているオブジェクトのisTrigger(コライダー設定)が有効⇩
    // かつ他のオブジェクトがすり抜けた時に中の処理を行うイベント関数⇩
    void OnTriggerEnter(Collider other)
    {
        audioManager.SEPlay(0);
        Score += 1;
        ScoreText.text = $"スコア：{Score}";
        // 変数名 otherってなに？
        // A.すり抜けた相手のコライダー情報
        Debug.Log($"{other.name}がすり抜けました。");
        // Destroy関数
        // Destroy(破棄したいオブジェクト)
        // オブジェクトが使用しているメモリの解放(ガベージコレクション)と描画情報の破棄
        Destroy(other.gameObject);
    }
}

