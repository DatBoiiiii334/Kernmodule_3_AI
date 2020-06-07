using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage_State : State
{
    private float LocalRageTime;
    private float LocalSpeed;
    private float RageSpeed;
    private float EnemyDistance = 4f;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Rage");
        LocalRageTime = ghost.RageTime;
        LocalSpeed = ghost.speed;
        RageSpeed = ghost.speed + 2f;
        ghost.KillGhost = true;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.KillGhost = false;
        ghost.speed = LocalSpeed;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        LocalRageTime -= Time.deltaTime;
        ghost.myMat.SetColor("_Color", Color.red);
        float distance = Vector3.Distance(ghost.transform.position, ghost.player.transform.position);
        PathRequestManager.RequestPath(ghost.transform.position, ghost.player.transform.position, ghost.OnPathFound);

        if (distance < EnemyDistance) {
            ghost.speed = RageSpeed;
        }
        else {
            ghost.speed = LocalSpeed;
        }

        if (LocalRageTime <= 0) {
            ghost.ChangeState("Flee");
        }
    }
}
