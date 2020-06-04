using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Ghost : Base_Ghost
{
    protected Blue_Ghost()
    {
        myHealth = 1;
        speed = 3;
        RageTime = 4;
        IdleTime = 10;
        FleeTime = 4;

        myStateDictionary.Add("Patrol", new Patrol_State());
        myStateDictionary.Add("Flee", new Flee_State());
        myStateDictionary.Add("Rage", new Rage_State());
        myStateDictionary.Add("Idle", new Idle_State());
        myState = myStateDictionary["Patrol"];

        if (myState != null) {
            myState.OnEnter(this);
        }
    }
}
