using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class BaseHState
    {
    Human myHuman;
    Target myTarget;
    public abstract void Initialise(Human human,Target target);
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void Deinitialise();
    }

