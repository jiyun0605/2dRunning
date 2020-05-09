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
    public int point;
    // Start is called before the first frame update

    public void ShowNeed()
    {
        if (help == null)
            return;
        help.SetActive(true);
    }
    public void GetItem(int code)
    {
        Destroy(help);
        if (code == needItemCode)
            Succes();
        else
            Fail();
    }

    private void Fail()
    {
        sad.SetActive(true);
    }

    private void Succes()
    {
        PlayerRun.player.SetScore(point);
        smile.SetActive(true);
        if (isJail)
            jail.SetActive(false);

    }
}
