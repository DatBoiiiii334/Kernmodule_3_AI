using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("New Actions/SearchItem")]
    [Help("Look for an item in the map")]
    public class SearchItem : GOAction
    {

        [InParam("searchObjectName")]
        public string searchObjectName;

        //[InParam("target")]
        //public GameObject mytarget;

        [InParam("health")]
        public int myHealth;

        [InParam("speed")]
        public float speed;

        public GameObject[] allHealingItems;

        public GameObject mytarget;
        private Rigidbody myRigidbody;
        private Vector3[] path;
        private int targetIndex;

        private float minDist = Mathf.Infinity;

        public override TaskStatus OnUpdate()
        {

            if (allHealingItems == null) {
                allHealingItems = GameObject.FindGameObjectsWithTag(searchObjectName);
            }

            foreach (GameObject medicine in allHealingItems) {

                float dist = Vector3.Distance(medicine.transform.position, gameObject.transform.position);
                if (dist < minDist) {
                    mytarget = medicine;
                    minDist = dist;
                }
            }

            if (mytarget == null) {
                return TaskStatus.FAILED;
            }
            else if(!mytarget.activeInHierarchy) {
                return TaskStatus.FAILED;
            }

            DoIt(gameObject.transform.position, mytarget.transform.position);
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
    }
}
