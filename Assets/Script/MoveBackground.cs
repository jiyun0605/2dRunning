using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerRun>().isStart)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
