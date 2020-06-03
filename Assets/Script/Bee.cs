using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : EnemyEntity
{
    Animator animator;
    bool attackStart;
    public GameObject bullet;
    public int delay;
    public Vector3 vector;
    public override void OnDamage()
    {
        base.OnDamage();
        animator.SetTrigger("Hit");
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       animator.SetBool("start", PlayerRun.player.isStart);
        if (!attackStart && PlayerRun.player.isStart)
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        attackStart = true;
        while(PlayerRun.player.isStart)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(vector), transform);
            yield return new WaitForSeconds(delay);
        }
        
    }
}
