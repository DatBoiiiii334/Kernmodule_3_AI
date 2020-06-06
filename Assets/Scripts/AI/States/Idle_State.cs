using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : State
{
    private float LocalIdleTime;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Idle");
        LocalIdleTime = ghost.IdleTime;
        ghost.KillPlayer = false;
        
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.NewRoute();
        ghost.KillPlayer = true;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        LocalIdleTime -= Time.deltaTime;
        ghost.myMat.SetColor("_Color", Color.yellow);
        PathRequestManager.RequestPath(ghost.transform.position, ghost.transform.position, ghost.OnPathFound);

        if(LocalIdleTime <= 0) {
            ghost.ChangeState("Patrol");
        }
    }
}