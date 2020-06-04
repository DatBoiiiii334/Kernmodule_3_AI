using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tagged_State : State
{
    private float Timer = 4f;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Tagged");
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.myHealth = 1;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        PathRequestManager.RequestPath(ghost.transform.position, ghost.spawn.transform.position, ghost.OnPathFound);
    }

    private IEnumerator RespawnTime(Base_Ghost ghost)
    {
        yield return new WaitForSeconds(Timer);
        ghost.StopCoroutine(RespawnTime(ghost));
        ghost.ChangeState("Patrol");
    }
}
