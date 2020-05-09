using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerRun : MonoBehaviour
{
    public static PlayerRun player;
    public int score;
    public int sceneCode;
    public GameObject GameOver;
    public GameObject end;
    public int coin;
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
    bool damaged;
    bool jumpEnable;
    bool isJumping;
    bool canShoot;
    public bool isStart;
    public bool isEnd;
    float maxHp;
    float curHp;
    private void Start()
    {
        player = this;
        jumpCnt = 0;
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpEnable = true;
        canShoot = true;
        maxHp = GameManager.instance.playerHp;
        curHp = maxHp;
        hpSlider.value = 1;
    }
    private void Update()
    {
        if (!isStart && Input.anyKeyDown&&!isEnd)
            isStart = true;
        if (isStart)
        {
            animator.SetTrigger("Start");
            curHp -= 1 * Time.deltaTime;
            hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, 0.3f);
        }
       
    }
    public void OnDamaged(int d)
    {
        if (damaged)
            return;
        animator.SetTrigger("Hit");
        damaged = true;
        curHp -= d;
        if (curHp <= 0)
            Die();
    }
    IEnumerator DamagedLimit()
    {
        yield return new WaitForSeconds(0.4f);
        damaged = false;
    }
    IEnumerator JumpLimit()
    {
        yield return new WaitForSeconds(0.5f);
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
            isEnd = true;
            isStart = false;
            end.SetActive(true);
            highScore.gameObject.SetActive(GameManager.instance.SetSocre(score, sceneCode));
            endText.text = score.ToString();
            GameManager.instance.coin += coin;
        }
        if (collision.gameObject.tag == "Coin")
        {
            coin++;
            coinTxt.text = coin.ToString();
            Destroy(collision.gameObject);
        }
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
}

