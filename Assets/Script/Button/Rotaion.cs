using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaion : ButtonAction
{
    public float r;
    public override void Start()
    {
        base.Start();
    }
    public override void Action()
    {
        base.Action();
        StartCoroutine(rotaion());

    }
    IEnumerator rotaion()
    {
        for(int i=(int)transform.rotation.z;i<r;i++)
        {
            transform.Rotate(new Vector3(0, 0, 1), Space.Self);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
