using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : State
{
    public override void OnEnter(Base_Ghost ghost) { Debug.Log("Flee"); }

    public override void OnExit(Base_Ghost ghost) { }

    public override void OnUpdate(Base_Ghost ghost) { }
}