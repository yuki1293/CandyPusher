using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 10000;

    public int createCost = 100;
    public int rewardMoney = 100;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI bonusTimeText;


    // ボーナス関連
    public int requiredCandyCount = 10;   // 何個落としたらボーナス開始？
    public float bonusTime = 10f;          // ボーナスの秒数
    public int bonusMultiplier = 5;       // 何倍にする？
    private bool isBonus = false;         // ボーナス中か？
    private float bonusTimer = 0f;        // ボーナス残り時間

    private int dropCount = 0;            // 落としたキャンディ数




    void Start()
    {
        UpdateMoneyText();
    }


    // キャンディ生成時にコインを使う
    public bool UseMoney()
    {
        if (money >= createCost)
        {
            money -= createCost;
            UpdateMoneyText();
            return true;
        }

        Debug.Log("コインが足りません");
        return false;
    }


    // キャンディが落ちたときに呼ばれる
    public void GetMoney()
    {
        dropCount++;

        // ボーナス開始条件
        if (dropCount >= requiredCandyCount && !isBonus)
        {
            StartBonus();
        }

        // ボーナス中なら倍率をかける
        int getMoney = rewardMoney;
        if (isBonus)
        {
            getMoney *= bonusMultiplier;
        }

        money += getMoney;
        UpdateMoneyText();

        Debug.Log(getMoney + "コイン獲得！（ボーナス中：" + isBonus + ")");
    }


    // ボーナス開始
    void StartBonus()
    {
        isBonus = true;
        bonusTimer = bonusTime;
        dropCount = 0;

        bonusTimeText.gameObject.SetActive(true);

        // ★ ここを変更
        bonusTimeText.text = "コイン" + bonusMultiplier + "倍中：残り " + bonusTimer.ToString("F1") + "秒";

        Debug.Log("🔥 ボーナスタイム開始！ " + bonusTime + "秒間コイン" + bonusMultiplier + "倍！");
    }




    void Update()
    {
        if (isBonus)
        {
            bonusTimer -= Time.deltaTime;

            // ★ ここを変更
            bonusTimeText.text = "コイン" + bonusMultiplier + "倍中：残り " + bonusTimer.ToString("F1") + "秒";

            if (bonusTimer <= 0)
            {
                isBonus = false;
                bonusTimeText.gameObject.SetActive(false);

                Debug.Log("ボーナスタイム終了。通常に戻ります。");
            }
        }
    }




    void UpdateMoneyText()
    {
        moneyText.text = "コイン：" + money;
    }
}
