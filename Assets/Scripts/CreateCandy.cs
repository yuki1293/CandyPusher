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

    // 4.�֐�AddCandy���쐬
    //�@�^�@���O�@
    public void AddCandy()
    {
        AudioManager.instance.SEPlay(1);
        // �T.�֐�AddCandyCount�̒���CandyCount��1���₷
        CandyCount = CandyCount + 1;
        
        
        // 6.�֐�AddCandy�̒���CandyCount�̒l�R���\�[��(Debug.Log())�ɕ\������
        Debug.Log(CandyCount);
        //　0 ~ CandyPrefabsの要素数-1までのランダムな整数を取得
        // 0 ~ 99までのランダムな整数を取得(百分率用)
        int rand = Random.Range(0, 100);
        int CandyType = 0;


        // それぞれの当選確率
        // もしもrandが50未満ならcandyTypeを0
        if(rand < 50)
        {
            CandyType = 0;
        }
        //もしもrandが50以上80未満ならcandyTypeを1
        else if (rand < 80)
        {
            CandyType = 1;
        }
        //もしもrandが80以上99未満ならcandyTypeを2
        else if(rand < 99)
        {
            CandyType =2;
        }

       
        // �I�u�W�F�N�g�̐������@
        // �^�@�ϐ��@���@�����l(Instantiate�ō��ꂽ�I�u�W�F�N�g)
        GameObject createPrefab = Instantiate(CandyPrefabs[CandyType]);

        // position�����g(�R�[�h���A�^�b�`����Ă���I�u�W�F�N�g�j�Ɠ����ɂ���
        createPrefab.transform.position = this.transform.position;
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
