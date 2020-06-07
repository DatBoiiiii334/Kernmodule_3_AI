using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee_State : State
{
    private float LocalIdleTime;
    private float LocalSpeed;
    private float EnemyDistance = 4f;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Idle");

        LocalIdleTime = ghost.IdleTime;
        ghost.KillPlayer = false;
        LocalSpeed = ghost.speed;
        ghost.speed += 2;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.speed = LocalSpeed;
        ghost.NewRoute();
        ghost.KillPlayer = true;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        LocalIdleTime -= Time.deltaTime;
        float distance = Vector3.Distance(ghost.transform.position, ghost.player.transform.position);
        ghost.myMat.SetColor("_Color", Color.yellow);

        if (LocalIdleTime <= 0) {
            ghost.ChangeState("Patrol");
        }

        if (distance < EnemyDistance) {
            Vector3 dirToPlayer = ghost.transform.position - ghost.player.transform.position;
            Vector3 newPos = ghost.transform.position + dirToPlayer;
            PathRequestManager.RequestPath(ghost.transform.position, dirToPlayer, ghost.OnPathFound);
        }
        else {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.transform.position, ghost.OnPathFound);
        }
    }
}
