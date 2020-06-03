using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ButtonAction
{
    public Vector2 v;
    public string corutine;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    public override void Action()
    {
        base.Action();
        StartCoroutine(corutine);
    }

    IEnumerator moveX()
    {
        for(int i=0;i<v.x;i++)
        {
            transform.position += new Vector3(1, 0);
            yield return new WaitForSeconds(0.001f);
        }

    }
    IEnumerator moveY()
    {
        for (int i = 0; i < v.y; i++)
        {
            transform.position += new Vector3(0, 1);
            yield return new WaitForSeconds(0.001f);
        }

    }
}
