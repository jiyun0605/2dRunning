using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public Button[] buttons;
    public Sprite bnt;
    public Sprite locked;
    public GameObject back;
    public Transform[] xPos;
    int i = 0;
    private void Start()
    {
        SoundManager.soundManager.BGMPlay(0);
        for(int i=0;i<buttons.Length;i++)
        {
            bool plag = GameManager.instance.stageClear[i];
            Sprite tmp = plag ? bnt : locked;
            buttons[i].GetComponent<Image>().sprite = tmp;
            buttons[i].enabled = plag;
            buttons[i].transform.GetChild(0).gameObject.SetActive(plag);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(4);
    }

    public void LoadScene(int n)
    {
         SoundManager.soundManager.SFXPlay(11);
        SceneManager.LoadScene(n);
    }

    public void MoveBack(int n)
    {
        int tmp = i;
        i += n;
        if (i >= xPos.Length || i < 0)
        {
            i = tmp;
            return;
        }
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(back.transform.position.x!=xPos[i].position.x)
        {
            Vector3 vector3 = new Vector3(xPos[i].position.x, back.transform.position.y);
            back.transform.position = Vector3.Lerp(back.transform.position, vector3,0.8f);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
