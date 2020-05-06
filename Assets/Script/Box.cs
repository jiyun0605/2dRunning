using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : EnemyEntity
{ 
    public GameObject dropItem;
    public GameObject[] piece;
    public Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void OnDamage()
    {
        base.OnDamage();
        if (HP <= 0)
            Broke();
    }

    public void Broke()
    {
        for(int i=0;i<piece.Length;i++)
        {
            Instantiate(piece[i], transform.position, Quaternion.identity);
        }
        Instantiate(dropItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
