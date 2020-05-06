using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public int HP;

    public virtual void OnDamage()
    {
        HP--;

    }
}
