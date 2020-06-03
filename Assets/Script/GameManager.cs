using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int[] score = { 0 };
    public bool[] stageClear = { false };
    public float playerHp = 300;
    public Skill skill;
    public bool[] store = { false };
    // Start is called before the first frame update
    void Awake()
    {
        stageClear[0] = true;
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        
    }
    private void Start()
    {
        LoadData();
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
   
    public string fileName = ".json";
    public Data _data;
    public Data data
    {
        get
        {
            if (_data == null)
            {
                LoadData();
                SaveData();
            }
            return _data;
        }
    }
    [ContextMenu("save")]
    private void SaveData()
    {
        data.stageClear = stageClear;
        data.score = score;
        data.store = store;
        string toJson = JsonUtility.ToJson(data);
        string filepaht = Application.persistentDataPath + fileName;
        File.WriteAllText(filepaht, toJson);
        Debug.Log(filepaht);
    }
    [ContextMenu("load")]
    private void LoadData()
    {
        string filePaht = Application.persistentDataPath + fileName;
        if (File.Exists(filePaht))
        {

            string FromJsonData = File.ReadAllText(filePaht);
            _data = JsonUtility.FromJson<Data>(FromJsonData);
            stageClear = _data.stageClear;
            score = _data.score;
            store = _data.store;
            
        }
        else
        {
            _data = new Data();
        }
    
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}

[System.Serializable]
public class Data
{
    public bool[] stageClear;
    public int[] score;
    public bool[] store;
}
