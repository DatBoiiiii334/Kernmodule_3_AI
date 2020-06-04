using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee_State : State
{
    private float localFleeTime;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Flee");
        localFleeTime = ghost.FleeTime;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.RescueGhost = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        PathRequestManager.RequestPath(ghost.transform.position, ghost.spawn.transform.position, ghost.OnPathFound);

        if (ghost.GotRescuedGhost == true) {
            ghost.ChangeState("Patrol");
        }
        else {
            if (ghost.InFleeZone == true) {
                localFleeTime -= Time.deltaTime;
            }

            if (localFleeTime <= 0) {
                ghost.ChangeState("Patrol");
            }
        } 
    }
}
