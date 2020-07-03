using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("New Actions/RotateToTarget")]
    [Help("Shoots hostiles on sight")]
    public class RotateGameObject : GOAction
    {

        // The target marker.
        [InParam("target")]
        [Help("target to turn to")]
        public Transform target;

        // Angular speed in radians per sec.
        [InParam("turnSpeed")]
        [Help("turnSpeed to face target")]
        public float turnSpeed = 1.0f;

        public Quaternion targetRotation;

        public override TaskStatus OnUpdate()
        {
            targetRotation = Quaternion.LookRotation(target.position - gameObject.transform.position);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


            RaycastHit hit;
            if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward, out hit, Mathf.Infinity)) {
                if(hit.collider.tag == "Player") {
                    return TaskStatus.COMPLETED;
                }
            }
            return TaskStatus.FAILED;

            //Vector3 targetDirection = target.transform.position - gameObject.transform.position;

            //float singleStep = turnSpeed * Time.deltaTime;

            //Vector3 newDirection = Vector3.RotateTowards(gameObject.transform.forward, targetDirection, singleStep, 0.0f);

            ////Debug.DrawRay(transform.position, newDirection, Color.red);

            //gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
            ////gameObject.transform.rotation = Quaternion.LookRotation(target.transform.position);
        }
    }
}
