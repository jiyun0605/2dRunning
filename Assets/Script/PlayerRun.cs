using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerRun : MonoBehaviour
{
    public int bgmcode;
    public static PlayerRun player;
    public int score;
    public int stageCode;
    public GameObject GameOver;
    public GameObject end;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI coinTxt;

    public GameObject bullet;
    Animator animator;
    Rigidbody2D rd2d;
    public float jumpPower;
    public Slider hpSlider;
    int jumpCnt;
    public bool damaged;
    bool jumpEnable;
    public bool isJumping;
    bool canShoot;
    public bool isStart;
    public bool isEnd;
    public float maxHp;
    public float curHp;

    bool isStop;
    public GameObject stop;
    private void Start()
    {
        if(!SoundManager.soundManager.BGM[bgmcode].isPlaying)
             SoundManager.soundManager.BGMPlay(bgmcode);
        Time.timeScale = 1;
        player = this;
        jumpCnt = 0;
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpEnable = true;
        canShoot = true;
        maxHp = GameManager.instance.playerHp;
        curHp = maxHp;
        GameManager.instance.skill.skillStart();
        
        hpSlider.value = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isStop||isEnd) SceneManager.LoadScene(2);
            else
            {
                isStop = true;
                stop.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (!isStart && Input.anyKeyDown&&!isEnd)
            isStart = true;
        if (isStart)
        {
            if (curHp <= 0)
                Die();
            animator.SetTrigger("Start");
            curHp -= 1 * Time.deltaTime;
            hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, 0.3f);
        }
       
    }

    public void OnDamaged(int d)
    {
        if (damaged)
            return;
        SoundManager.soundManager.SFXPlay(3);
        animator.SetTrigger("Hit");
        damaged = true;
        curHp -= d;
        StartCoroutine(DamagedLimit());
    }
    IEnumerator DamagedLimit()
    {
        yield return new WaitForSeconds(0.5f);
        damaged = false;
        transform.position = new Vector3(-7, transform.position.y);
    }
    IEnumerator JumpLimit()
    {
        yield return new WaitForSeconds(0.2f);
        jumpEnable = true;
    }
    IEnumerator ShootLimit()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
    public void JumpButton()
    {
        if(isStart& jumpEnable)
        {
            if (jumpCnt >= 2)
                return;
            jumpEnable = false;
            StartCoroutine(JumpLimit());
            jumpCnt++;
            Jump();
            SoundManager.soundManager.SFXPlay(0);
        }
    }
    void Jump()
    {
        animator.SetTrigger("Jump");
        Vector3 vector = Vector3.zero;
        vector = new Vector3(rd2d.velocity.x, jumpPower);
        rd2d.velocity = vector;
    }
    public void shoot()
    {
        if (!canShoot)
            return;
        SoundManager.soundManager.SFXPlay(2);
        Instantiate(bullet, transform.position, Quaternion.identity);
        canShoot = false;
        StartCoroutine(ShootLimit());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            jumpCnt = 0;
            jumpEnable = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            End();
        }
    }
    public void End()
    {
        isEnd = true;
        isStart = false;
        end.SetActive(true);
        score += (int)(hpSlider.value * 10000);
        highScore.gameObject.SetActive(GameManager.instance.SetSocre(score, stageCode));
        endText.text = score.ToString();
        if (stageCode + 1 > 6)
            return;
        GameManager.instance.stageClear[stageCode + 1] = true;
    }
    public void Die()
    {
        GameOver.SetActive(true);
        isEnd = true;
        isStart = false;
    }
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }
    
    public void SetScore(int n)
    {
        score += n;
        scoreText.text = score.ToString();
    }

    public void Exit()
    {
        isStop = false;
        SceneManager.LoadScene(2);
    }
    public void Continue(GameObject gameObject)
    {
        Time.timeScale = 1;
        isStart = false;
        gameObject.SetActive(false);
       
    }
}

