using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        Rigidbody2D rd= GetComponent<Rigidbody2D>();
        rd.AddForce(dir * 10, ForceMode2D.Impulse);
    }

}
