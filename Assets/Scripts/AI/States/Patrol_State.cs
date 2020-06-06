using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_State : State
{
    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Patrol");
        ghost.RescueGhost = true;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.KillPlayer = false;
        ghost.RescueGhost = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        ghost.KillPlayer = true; ghost.myMat.SetColor("_Color", Color.blue);
        if (ghost.transform.position != ghost.player.transform.position) {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.target.transform.position, ghost.OnPathFound);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ghost.ChangeState("Idle");
        }
    }
}
