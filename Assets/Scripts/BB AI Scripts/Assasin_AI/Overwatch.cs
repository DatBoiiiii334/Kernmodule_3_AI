using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("New Actions/Overwatch")]
    [Help("Shoots hostiles on sight")]
    public class Overwatch : GOAction
    {
        [InParam("shootPoint")]
        public Transform shootPoint;

        [InParam("bullet")]
        public GameObject bullet;

        [InParam("velocity", DefaultValue = 30f)]
        public float velocity;

        [InParam("target")]
        public GameObject target;

<<<<<<< Updated upstream
        [InParam("closeDistance")]
        public float closeDistance;

        [InParam("turnSpeed")]
        [Help("turnSpeed to face target")]
        public float turnSpeed = 1.0f;

        private float FireRate;


=======
        [InParam("closeDistance", DefaultValue = 10.0f)]
        public float closeDistance;

        [InParam("turnSpeed", DefaultValue = 7.0f)]
        [Help("turnSpeed to face target")]
        public float turnSpeed;

        private float FireRate;

>>>>>>> Stashed changes
        [InParam("layerMask")]
        public LayerMask layerMask;
        private Quaternion targetRotation;

        public override TaskStatus OnUpdate()
        {
            if (shootPoint == null) {
                Debug.LogWarning("shoot point not specified. ShootOnce will not work for " + gameObject.name);
                return TaskStatus.FAILED;
            }

            targetRotation = Quaternion.LookRotation(target.transform.position - gameObject.transform.position);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, shootPoint.forward, out hit, Mathf.Infinity, layerMask)) {
                if (hit.collider.tag == "Player") {
<<<<<<< Updated upstream

                    FireBullet();

                    return TaskStatus.COMPLETED;
                }
                else {
                    return TaskStatus.FAILED;
                }

            }

            return TaskStatus.FAILED;
=======
                    FireBullet();
                    return TaskStatus.RUNNING;
                }
                else {
                    return TaskStatus.COMPLETED;
                }
            }
            return TaskStatus.RUNNING;
>>>>>>> Stashed changes
        }

        void FireBullet()
        {
<<<<<<< Updated upstream
            GameObject newBullet = GameObject.Instantiate(bullet, shootPoint.position, shootPoint.rotation * bullet.transform.rotation);
=======
            Vector3 newpoint = new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z - 0.5f);
            GameObject newBullet = GameObject.Instantiate(bullet, newpoint, shootPoint.rotation * bullet.transform.rotation);
>>>>>>> Stashed changes
            if (newBullet.GetComponent<Rigidbody>() == null) {
                newBullet.AddComponent<Rigidbody>();
            }
            newBullet.GetComponent<Rigidbody>().velocity = velocity * shootPoint.forward;
        }
    }
}
