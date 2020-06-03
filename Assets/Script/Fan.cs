using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float p;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            float power = p / (collision.gameObject.transform.position.y - transform.position.y);
            Vector3 vector = Vector3.up *power;
            Rigidbody2D rd = collision.gameObject.GetComponent<Rigidbody2D>();
            rd.AddForce(vector, ForceMode2D.Impulse);
        }
    }

}
