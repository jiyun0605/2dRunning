using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWall : NPC
{

    public override void GetItem(int code)
    {
        SoundManager.soundManager.SFXPlay(4);
        if (code != needItemCode)
            return;
        PlayerRun.player.SetScore(point);
        Destroy(gameObject);

    }
}
