using UnityEngine;

public class StageOut : MonoBehaviour
{
    public MoneyManager moneyManager;

    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.SEPlay(0);

        // キャンディが落ちたのでコイン獲得処理へ
        moneyManager.GetMoney();

        Debug.Log(other.name + "が落ちました");

        Destroy(other.gameObject);
    }
}
