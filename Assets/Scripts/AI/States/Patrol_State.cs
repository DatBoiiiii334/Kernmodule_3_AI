using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_State : State
{

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Patrol");

    }

    public override void OnExit(Base_Ghost ghost)
    {

    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        PathRequestManager.RequestPath(ghost.transform.position, ghost.target.transform.position, ghost.OnPathFound);

        //In case the one of the ghost's gets stuck you can manually force them to change their path
        if (Input.GetKeyDown(KeyCode.Space)) {
            ghost.ChangeState("Idle");
        }
    }
}
