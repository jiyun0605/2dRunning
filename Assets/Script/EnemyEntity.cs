using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public int HP;
    public int sfxCode;
    public virtual void OnDamage()
    {
        SoundManager.soundManager.SFXPlay(sfxCode);
        HP--;
        if (HP < 0)
        {
            Destroy(gameObject);
            PlayerRun.player.SetScore(500);
        }
    }
}
