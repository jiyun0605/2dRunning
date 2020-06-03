using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : Trap
{

    public Rigidbody2D rigidbody2;
    public float leftPush;
    public float rightPush;
    public float angle;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        rigidbody2.angularVelocity = angle;
    }
    private void Update()
    {
        if (!PlayerRun.player.isStart)
            return;
        if(transform.rotation.z>0&&transform.rotation.z>rightPush&&rigidbody2.angularVelocity<angle)
        {
            rigidbody2.angularVelocity = angle;
        }
        else if(transform.rotation.z<0&&transform.rotation.z<leftPush&&rigidbody2.angularVelocity<0&&rigidbody2.angularVelocity>angle*-1)
        {
            rigidbody2.angularVelocity = angle * -1;
        }
    }
}
