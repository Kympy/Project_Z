using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    public virtual void Awake()
    {
        InitRigidbody();
        InitAnimator();
    }
}
