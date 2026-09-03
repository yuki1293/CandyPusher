using UnityEngine;
using TMPro;

public class CandyDropCounter : MonoBehaviour
{
    public int dropCount = 0;
    public TextMeshProUGUI dropText;

    void Start()
    {
        UpdateUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candy"))
        {
            dropCount++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        dropText.text = "落ちたキャンディ: " + dropCount;
    }
}
