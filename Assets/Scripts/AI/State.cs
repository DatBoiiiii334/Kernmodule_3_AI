using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void OnEnter(Base_Ghost ghost);
    public abstract void OnUpdate(Base_Ghost ghost);
    public abstract void OnExit(Base_Ghost ghost);
}
