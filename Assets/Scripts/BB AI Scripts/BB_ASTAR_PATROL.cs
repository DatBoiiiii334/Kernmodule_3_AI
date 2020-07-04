using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;


namespace BBUnity.Actions
{
    [Action("Navigation/A*_Pathfinding")]
    [Help("Moves the game object to a given position by using a A* Pathfinding")]
    public class BB_ASTAR_PATROL : GOAction
    {
        [InParam("path waypoint")]
        [Help("Your special selected number of worlds")]
        public GameObject target;

        [InParam("mySpeed")]
        [Help("Your speed")]
        public float speed;

        [InParam("health")]
        [Help("Enemy health")]
<<<<<<< Updated upstream
        public int health;
=======
        public float health;
>>>>>>> Stashed changes

        [InParam("Mono")]
        [Help("Enemy health")]
        public MonoHP _monoInstance;

        private Rigidbody myRigidbody;
        private Vector3[] path;
        private int targetIndex;

        public override void OnStart()
        {
            myRigidbody = gameObject.GetComponent<Rigidbody>();

            if (myRigidbody == null) {
                Debug.LogError("PLEASE ADD RIGIDBODY COMPONENT TO UNIT !!!!");
            }
        }

        public override TaskStatus OnUpdate()
        {
            OnStart();
            DoIt(gameObject.transform.position, target.transform.position);
            return TaskStatus.RUNNING;
        }

        public void DoIt(Vector3 me, Vector3 target)
        {
            PathRequestManager.RequestPath(me, target, OnPathFound);
        }

        public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
        {
            if (pathSuccessful) {
                path = newPath;
                targetIndex = 0;
                OnUpdateAsCoroutine(false);
                OnUpdateAsCoroutine(true);
            }
        }

        public void OnUpdateAsCoroutine(bool On)
        {
            if (On) {
                if (targetIndex >= path.Length) {
                    targetIndex = 0;
                    path = new Vector3[0];
                    return;
                }

                targetIndex = 0;
                Vector3 currentWaypoint = path[0];
                Vector3 targetDir = currentWaypoint - gameObject.transform.position;
                float step = speed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(gameObject.transform.forward, targetDir, step, 0.0F);
                gameObject.transform.rotation = Quaternion.LookRotation(newDir);

                while (true) {
                    if (gameObject.transform.position == currentWaypoint) {
                        targetIndex++;

                        if (targetIndex >= path.Length) {
                            targetIndex = 0;
                            path = new Vector3[0];
                            return;
                        }
                        currentWaypoint = path[targetIndex];
                    }
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentWaypoint, speed * Time.deltaTime);
                    return;
                }
            }
        }

        public void OnDrawGizmos()
        {
            if (path != null) {
                for (int i = targetIndex; i < path.Length; i++) {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(path[i], Vector3.one);

                    if (i == targetIndex) {
                        Gizmos.DrawLine(gameObject.transform.position, path[i]);
                    }
                    else {
                        Gizmos.DrawLine(path[i - 1], path[i]);
                    }
                }
            }
        }

        public void GiveDamage(int damage)
        {
            health -= damage;
            Debug.Log("Stop hitting me!" + health);
        }
    }
}

