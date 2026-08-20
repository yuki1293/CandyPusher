using UnityEngine;
using TMPro;

public class StageOut : MonoBehaviour
{
    private int Score = 0;

    public TextMeshProUGUI ScoreText;

    // 落としたコインの枚数
    private int coinCount = 0;

    // 何枚落としたらスコア2倍にするか
    public int requiredCoinCount = 10;

    // スコア2倍になっているか
    private bool scoreUp = false;

    // スコア2倍になる時間
    public float scoreUpTime = 10f;

    // スコア2倍の残り時間
    private float timer = 0f;
    // 残り時間を表示するText
    public TextMeshProUGUI TimerText;


    void Update()
    {
        Debug.Log("scoreUp = " + scoreUp);

        if (scoreUp)
        {
            timer -= Time.deltaTime;

            TimerText.text =
                "スコア2倍 残り：" + Mathf.Ceil(timer) + "秒";

            Debug.Log("timer = " + timer);

            if (timer <= 0)
            {
                scoreUp = false;
                TimerText.text = "";

                Debug.Log("スコア2倍終了！");
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.SEPlay(0);

        // 落としたコインの数を1増やす
        coinCount++;

        Debug.Log("落としたコイン：" + coinCount);

        // スコアを追加する
        int addScore = 1;

        // スコア2倍中なら2点
        if (scoreUp)
        {
            addScore = 2;
        }

        Score += addScore;

        ScoreText.text = $"スコア：{Score}";

        Debug.Log($"{other.name}がすり抜けました。");

        // 一定数落としたか確認
        if (coinCount >= requiredCoinCount)
        {
            StartScoreUp();

            // カウントを0に戻す
            coinCount = 0;
        }

        Destroy(other.gameObject);
    }


    // スコア2倍を開始する
    public void StartScoreUp()
    {
        scoreUp = true;

        timer = scoreUpTime;

        Debug.Log("スコア2倍開始！");
    }
}