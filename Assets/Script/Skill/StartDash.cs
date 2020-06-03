using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDash : Skill
{
    public float delay;
    public override void skillStart()
    {
        MoveBackground move = FindObjectOfType<MoveBackground>();
        move.speed *= 2f;
    }

}
