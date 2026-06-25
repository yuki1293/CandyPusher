using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCandy : MonoBehaviour
{
    // 1.int型の変数を宣言、変数名はCandyCount
    // 2.1で宣言して変数をprivateniする
    // ３．変数CandyCountの初期値を０にする
    // アクセス修飾子　型　変数名　＝　初期値；
    private int CandyCount = 0;
    public GameObject CandyPrefab;

    // 4.関数AddCandyを作成
    //　型　名前　
    void AddCandy()
    {
        // ５.関数AddCandyCountの中でCandyCountを1個増やす
        CandyCount = CandyCount + 1;

        // 6.関数AddCandyの中でCandyCountの値コンソール(Debug.Log())に表示する
        Debug.Log(CandyCount);

        // オブジェクトの生成方法
        // 型　変数　＝　初期値(Instantiateで作られたオブジェクト)
        GameObject createPrefab = Instantiate(CandyPrefab);

        // positionを自身(コードがアタッチされているオブジェクト）と同じにする
        createPrefab.transform.position = this.transform.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //処理をしたい関数を書く
        AddCandy();
    }

    // Update is called once per frame
    void Update()
    {
        //if文　もしも（条件）がtrueならば{　}の処理をする
        if(Keyboard.current.spaceKey.isPressed)
        {
            AddCandy();
        }
    }
}
