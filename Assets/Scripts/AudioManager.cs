using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //シングルトン
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }


    public AudioSource audioSource;
    public AudioSource secondAudioSource;
    public AudioClip[] seAudioClips;

    private AudioSource seAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SEPlay(int i)
    {
        //　AddComponent<Component名>();
        if (seAudioSource == null)
        {
            seAudioSource = this.gameObject.AddComponent<AudioSource>();
        }
        seAudioSource.clip = seAudioClips[i];
        seAudioSource.Play();

    }


    //BGNを鳴らす処理
    // 1．BGMの音源(AudioClip)を管理する配列の作成
　　public AudioClip[] bgmAudioClips;
    // 2. BGMを流すAudioSourceを変数として作成
    private AudioSource bgmAudioSource;
    // 3. 関数　BGMPlayを作成。　2のAudioSourceをに配列の0番目の音源を渡す
    public void BGMPlay()
    {
      if(bgmAudioSource == null)
        {
            bgmAudioSource = this.gameObject.AddComponent<AudioSource>();
        }
        bgmAudioSource.clip = bgmAudioClips[0];
        bgmAudioSource.Play();
        bgmAudioSource.loop = true;;
    }
    void Start()
    {
        BGMPlay();
    }

    // 4.2のAudioSourceをPlay()する。

    // EX.Loop機能を"コード上から"設定する。

    // Update is called once per frame
    void Update()
    {
        
    }
}
