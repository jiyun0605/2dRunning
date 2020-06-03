using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 30);
    }
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * 3 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerRun>().OnDamaged(50);
            Destroy(gameObject);
        }
    }
}
