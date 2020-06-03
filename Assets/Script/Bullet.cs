using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyEntity enemy = collision.gameObject.GetComponent<EnemyEntity>();
        if (enemy == null)
            return;
        enemy.OnDamage();
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyEntity enemy = collision.gameObject.GetComponent<EnemyEntity>();
        if (enemy == null)
            return;
        enemy.OnDamage();
        Destroy(gameObject);
    }
}
