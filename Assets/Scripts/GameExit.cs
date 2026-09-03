using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("ゲーム終了ボタンが押されました");

        Application.Quit(); // ← ゲーム終了（ビルド時のみ動く）

        // Unityエディタで確認したい場合（エディタのみ）
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
