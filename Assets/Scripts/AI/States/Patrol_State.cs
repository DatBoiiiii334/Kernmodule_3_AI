using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_State : State
{
    private float EnemyDistance = 6f;

    public override void OnEnter(Base_Ghost ghost)
    {
        ghost.RescueGhost = true;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        ghost.KillPlayer = false;
        ghost.RescueGhost = false;
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        float distance = Vector3.Distance(ghost.transform.position, ghost.player.transform.position);
        ghost.KillPlayer = true; ghost.myMat.SetColor("_Color", Color.blue);

        if (distance < EnemyDistance) {
            Vector3 dirToPlayer = ghost.transform.position - ghost.player.transform.position;
            Vector3 newPos = ghost.transform.position - dirToPlayer;
            PathRequestManager.RequestPath(ghost.transform.position, ghost.player.transform.position, ghost.OnPathFound);
        }
        else {
            PathRequestManager.RequestPath(ghost.transform.position, ghost.target.transform.position, ghost.OnPathFound);
        }
    }
}
