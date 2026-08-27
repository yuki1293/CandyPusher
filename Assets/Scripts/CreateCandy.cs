using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCandy : MonoBehaviour
{
    // 1.int�^�̕ϐ���錾�A�ϐ�����CandyCount
    // 2.1�Ő錾���ĕϐ���privateni����
    // �R�D�ϐ�CandyCount�̏����l���O�ɂ���
    // �A�N�Z�X�C���q�@�^�@�ϐ����@���@�����l�G
    private int CandyCount = 0;
    public GameObject CandyPrefab;
    // GameObjectの配列を作成
    public GameObject[] CandyPrefabs;

    

    //�����ړ��̂��߂̕ϐ�
    public float speed = 3.0f;
    public float moveRange = 2.3f;
    private float startX;

    public AudioManager audioManager;
    public MoneyManager moneyManager;
    // 4.�֐�AddCandy���쐬
    //�@�^�@���O�@
    public void AddCandy()
    {
        // コインを使える場合だけキャンディを生成する
        if (moneyManager.UseMoney())
        {
            AudioManager.instance.SEPlay(1);

            CandyCount++;

            Debug.Log(CandyCount);

            int rand = Random.Range(0, 100);
            int CandyType = 0;

            if (rand < 50)
            {
                CandyType = 0;
            }
            else if (rand < 80)
            {
                CandyType = 1;
            }
            else if (rand < 99)
            {
                CandyType = 2;
            }

            // キャンディを生成
            GameObject createPrefab =
                Instantiate(CandyPrefabs[CandyType]);

            // 生成位置を設定
            createPrefab.transform.position =
                transform.position;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {   startX = this.transform.position.x;
        //�������������֐�������
        AddCandy();

       
    }

    // Update is called once per frame
    void Update()
    {
        
 
        //if���@�������i�����j��true�Ȃ��{�@}�̏���������
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            AddCandy();

        }
    }
}
