using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public ButtonObject button;
    public virtual void Start()
    {
        button.action = this;
    }
    public virtual void Action()
    {

    }

}
