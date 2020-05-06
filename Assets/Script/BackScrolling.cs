using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrolling : MonoBehaviour
{
    public float speed;
    float x;
    private void Start()
    {        
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        x = box.size.x;
    }
    public void Update()
    {
        if(GameManager.instance.isStart)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x<=-x)
        {
            Vector2 vector = new Vector2(x-1.5f, 0);
           Instantiate(gameObject,vector, Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
