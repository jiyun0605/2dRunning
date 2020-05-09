using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : EnemyEntity
{
    public int point;
    public GameObject dropItem;
    public GameObject[] piece;
    public Animator animator;
    public GameObject back;
    public bool hasItem;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void OnDamage()
    {
        base.OnDamage();
        animator.SetTrigger("Hit");
        if (HP <= 0)
            Broke();
    }

    public void Broke()
    {
        PlayerRun.player.SetScore(point);
        for(int i=0;i<piece.Length;i++)
        {
            Instantiate(piece[i], transform.position, Quaternion.identity);
        }
        if(hasItem)
            Instantiate(dropItem, transform.position, Quaternion.identity,back.transform);
        Destroy(gameObject);
    }
}
