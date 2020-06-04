using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee_State : State
{
    private float FleeTimer;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Flee");
        FleeTimer = 1;
        PathRequestManager.RequestPath(ghost.transform.position, ghost.spawn.transform.position, ghost.OnPathFound);
    }

    public override void OnExit(Base_Ghost ghost)
    {
        FleeTimer = 1;
        ghost.RescueGhost = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        if (ghost.InFleeZone) {
            FleeTimer -= 0.2f * Time.deltaTime;
        }
        if (FleeTimer <= 0) {
            ghost.ChangeState("Patrol");
        }

        if (ghost.GotRescuedGhost == true) {
            ghost.ChangeState("Patrol");
        }
    }
}
