using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : State
{
    public float Timer = 1f;
    //private float ActualSpeed;
    //private int NewSpeed = 0;

    public override void OnEnter(Base_Ghost ghost)
    {
        Debug.Log("Idle");
        //ActualSpeed = ghost.speed;
    }

    public override void OnExit(Base_Ghost ghost)
    {
        //ghost.speed = ActualSpeed;
        ghost.NewRoute();
    }

    public override void OnUpdate(Base_Ghost ghost)
    {
        //ghost.speed = NewSpeed;
        PathRequestManager.RequestPath(ghost.transform.position, ghost.transform.position, ghost.OnPathFound);

        Timer -= 0.2f * Time.deltaTime;
        if(Timer <= 0) {
            ghost.ChangeState("Patrol");
        }
    }
}