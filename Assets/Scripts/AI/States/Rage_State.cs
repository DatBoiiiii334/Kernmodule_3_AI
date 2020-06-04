using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage_State : State
{
    private float RageTimer;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Rage");
        RageTimer = 4f;
        ghost.KillGhost = true;
        ghost.KillPlayer = true;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.KillGhost = false;
        ghost.KillPlayer = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        if(ghost.transform.position != ghost.player.transform.position) {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.player.transform.position, ghost.OnPathFound);
        }
        RageTimer -= 0.2f * Time.deltaTime;

        if (RageTimer <= 0) {
            ghost.ChangeState("Idle");
        }


    }
}
