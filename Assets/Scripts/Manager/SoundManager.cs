using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{
    enum BGM
    {
        Stage1,
        Stage2,
        Stage3,
    };

    enum SFX
    {
        Test1,
        Test2,
        Test3,
    };

    // SoundClip 보다 SoundSource로 하자.
    // BGM 전용, SFX 전용 따로 만들어야 될 것 같아.
    // Enum이 필요할까?
    public AudioSource[] bgmAudio;
    public AudioSource[] sfxAudio;
    public GameObject bgmTest;
    public GameObject sfxTest;

    private void Start()
    {
      
    }

    void CreateTest()
    {
        // Prefab 안에 있는 것을 선택하고 순회해서 bgmAudio, sfxAudio에 넣고 싶다.

    }

    public void PlayStage1()
    {
        AllStopBGM();
    }

    void AllStopBGM()
    {
        foreach (var bgm in bgmAudio)
        {
            bgm.Stop();
        }
    }

    void AllStopSFX()
    {
        foreach(var sfx in sfxAudio)
        {
            sfx.Stop();
        }
    }
   
}
