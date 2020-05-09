using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int[] score = { 0 };
    public float playerHp = 300;
    public int coin;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public bool SetSocre(int s,int c)
    {
        if (score[c] <= s)
        {
            score[c] = s;
            return true;
        }
        return false;
    }

}
