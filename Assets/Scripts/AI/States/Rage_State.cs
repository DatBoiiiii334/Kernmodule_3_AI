using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage_State : State
{
    private float LocalRageTime;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Rage");
        LocalRageTime = ghost.RageTime;
        ghost.KillGhost = true;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.KillGhost = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        ghost.myMat.SetColor("_Color", Color.red);
        LocalRageTime -= Time.deltaTime;

        if (ghost.transform.position != ghost.player.transform.position) {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.player.transform.position, ghost.OnPathFound);
        }

        if (LocalRageTime <= 0) {
            ghost.ChangeState("Idle");
        }
    }
}
