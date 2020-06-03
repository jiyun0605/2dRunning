using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    bool isDown;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            isDown = true;
            Destroy(gameObject, 3);
        }
    }
    private void Update()
    {
        if (!isDown)
            return;
        transform.position += Vector3.down * 10 * Time.deltaTime;

    }
}
