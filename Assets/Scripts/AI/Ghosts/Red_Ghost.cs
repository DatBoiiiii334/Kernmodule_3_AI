﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ghost : Base_Ghost
{
    protected Red_Ghost()
    {
        myHealth = 1;
        speed = 5;
        RageTime = 10;
        IdleTime = 10;
        TaggedTime = 4;

        myStateDictionary.Add("Patrol", new Patrol_State());
        myStateDictionary.Add("Flee", new Flee_State());
        myStateDictionary.Add("Rage", new Rage_State());
        myStateDictionary.Add("Tagged", new Tagged_State());
        myState = myStateDictionary["Patrol"];

        if (myState != null) {
            myState.OnEnter(this);
        }
    }
}
