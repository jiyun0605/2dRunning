using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float dis;
    // Start is called before the first frame update
    void Start()
    {
        dis = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(transform.position.x,target.position.y + dis,-50);
        transform.position = vector;
    }
}
