using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    Animator animator;
    public float power;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SoundManager.soundManager.SFXPlay(1);
            animator.SetTrigger("Play");
            Vector2 vector = Vector2.up * power;
            Rigidbody2D rd = collision.gameObject.GetComponent<Rigidbody2D>();
            rd.AddForce(vector, ForceMode2D.Impulse);
        }
    }
}
