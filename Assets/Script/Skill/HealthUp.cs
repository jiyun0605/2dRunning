using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Skill
{
    
    public override void skillStart()
    {
        Debug.Log(gameObject.name);
        PlayerRun.player.maxHp *= 1.5f;
        PlayerRun.player.curHp *= 1.5f;

    }
}
