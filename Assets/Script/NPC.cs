using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int needItemCode;
    public GameObject help;
    public GameObject smile;
    public GameObject sad;
    public GameObject jail;
    public bool isJail;
    bool get;
    public int point;
    // Start is called before the first frame update

    public void ShowNeed()
    {
        if (help == null)
            return;
        help.SetActive(true);
    }
    public virtual void GetItem(int code)
    {
        if (get)
            return;
        get = true;
        Destroy(help);
        if (code == needItemCode)
            Succes();
        else
            Fail();
    }

    private void Fail()
    {
        sad.SetActive(true);
        this.enabled = false;
        SoundManager.soundManager.SFXPlay(6);
    }

    private void Succes()
    {
        SoundManager.soundManager.SFXPlay(7);
        PlayerRun.player.SetScore(point);
        smile.SetActive(true);
        if (isJail)
            jail.SetActive(false);

    }
}
