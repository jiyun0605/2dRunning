using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rd2d;
    public float jumpPower;

    public int jumpCnt;
    public bool jumpEnable;
    public bool isJumping;
    private void Start()
    {
        jumpCnt = 0;
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpEnable = true;
    }
    private void Update()
    {
        if (GameManager.instance.isStart)
            animator.SetTrigger("Start");
    }

    IEnumerator InputKeyLimit()
    {
        yield return new WaitForSeconds(0.5f);
        jumpEnable = true;
    }
    public void JumpButton()
    {
        if(GameManager.instance.isStart& jumpEnable)
        {
            if (jumpCnt >= 2)
                return;
            jumpEnable = false;
            StartCoroutine(InputKeyLimit());
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            jumpCnt = 0;
            jumpEnable = true;
        }
    }

}
