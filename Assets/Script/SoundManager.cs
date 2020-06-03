using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioSource[] BGM;
    public AudioSource[] SFX;
    public StartMenu start;
    // Start is called before the first frame update
    void Start()
    {
        if (soundManager == null)
            soundManager = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void SoundSet()
    {
        for (int i = 0; i < BGM.Length; i++)
            BGM[i].volume = start.bgm.value;
        for (int i = 0; i < SFX.Length; i++)
            SFX[i].volume = start.sfx.value;
    }

    public void BGMPlay(int n)
    {
        if (BGM[n].isPlaying)
            return;
        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i].Stop();
        }
 
        BGM[n].Play();
    }
    public void SFXPlay(int n)
    {
        SFX[n].Play();
    }
}
