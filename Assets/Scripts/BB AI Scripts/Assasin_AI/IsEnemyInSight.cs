using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance and angle.
    [Condition("Perception/IsTargetInMySight")]
    [Help("Checks whether a target is close and in sight depending on a given distance and an angle")]
    public class IsEnemyInSight : GOCondition
    {
        [InParam("target")]
        [Help("this is my target")]
        public GameObject muhTarget;

        public override bool Check()
        {
            Vector3 dir = gameObject.transform.TransformDirection(Vector3.forward) * 10;
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0.1f, 0), dir, out hit, Mathf.Infinity)) {

                Debug.DrawRay(gameObject.transform.position, dir,Color.cyan);
                if(hit.collider.gameObject == muhTarget) {
                    Debug.DrawRay(gameObject.transform.position, dir, Color.red);
                }
                return hit.collider.gameObject == muhTarget;
                
            }

            return false;
        }
    }
}
