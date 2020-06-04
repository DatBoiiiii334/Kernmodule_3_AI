using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_State : State
{
    public override void OnEnter(Base_Ghost ghost) { Debug.Log("Patrol"); ghost.KillPlayer = true; }

    public override void OnExit(Base_Ghost ghost) { ghost.KillPlayer = false; }

    public override void OnUpdate(Base_Ghost ghost)
    {
        if (ghost.transform.position != ghost.player.transform.position) {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.target.transform.position, ghost.OnPathFound);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ghost.ChangeState("Idle");
        }
    }
}
