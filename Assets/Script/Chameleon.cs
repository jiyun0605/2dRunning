using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : EnemyEntity
{
    Animator animator;
    public float delay;
    public int damage;
   public bool canattack;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        canattack = true;
        animator = GetComponent<Animator>();
        StartCoroutine(Attack());
        animator.SetTrigger("attack");
        
    }

    IEnumerator Attack()
    {
        while (canattack)
        {
            yield return new WaitForSeconds(delay);
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void attack()
    {
        attacking = true;
    }
    public void noattack()
    {
        attacking = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player"&&attacking)
        {
            Debug.Log("t");
            collision.gameObject.GetComponent<PlayerRun>().OnDamaged(damage);
        }
    }
    public override void OnDamage()
    {
        base.OnDamage();
        animator.SetTrigger("hit");
        canattack = false;
 
    }
    public void wait()
    {
        canattack = true;
    }
}
