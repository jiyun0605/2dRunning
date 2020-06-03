using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public Slider bgm;
    public Slider sfx;
    public GameObject fail;
    public GameObject succes;
    public Skill[] skills;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()

    {

        if (SceneManager.GetActiveScene().buildIndex != 4)

        {

            SceneManager.LoadScene(4);

        }

    }
    public void soundSetting()
    {
        SoundManager.soundManager.SoundSet();
    }
    private void Start()
    {
        
        SoundManager.soundManager.start = this;
        SoundManager.soundManager.BGMPlay(0);

        bgm.value = SoundManager.soundManager.BGM[0].volume;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();
    }

    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void Opne(GameObject gameObject)
    {
        sfx.value = SoundManager.soundManager.SFX[0].volume;
        gameObject.SetActive(true);
    }
    public void Exit()
    {
        if (Advertisement.IsReady())
            Advertisement.Show();
        Application.Quit();
    }
    public void SkillSelect(int n)
    {
        GameObject go;
        if (GameManager.instance.store[n] || GameManager.instance.stageClear[n + 1])
        {
            go = Instantiate(succes, transform);
            Destroy(go, 1.5f);
            GameManager.instance.skill = skills[n];
            GameManager.instance.store[n] = true;
        }
        else
        {
            go = Instantiate(fail, transform);
            Destroy(go, 1.5f);
            return;
        }
        go = Instantiate(succes, transform);
        Destroy(go, 1.5f);
    }
    public void cancle(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public void Release()
    {
        GameManager.instance.skill = null;
    }
    public void buttonSound(int n)
    {
        SoundManager.soundManager.SFXPlay(n);
    }
}