﻿using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Renderer groundSize;

    private Vector3[] path;
    private int targetIndex;

    protected float minX, maxX, minZ, maxZ;

    public GameObject ground;
    protected float speed;

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        groundSize = ground.GetComponent<Renderer>();
    }

    void Start()
    {
        if (myRigidbody == null) {
            Debug.LogError("PLEASE ADD RIGIDBODY COMPONENT TO UNIT !!!!");
        }
        if (groundSize == null) {
            Debug.LogError("PLEASE ADD RENDERER TO GROUND GAMEOBJECT !!!!");
        }

        minX = (groundSize.bounds.center.x - groundSize.bounds.extents.x);
        maxX = (groundSize.bounds.center.x + groundSize.bounds.extents.x);
        minZ = (groundSize.bounds.center.z - groundSize.bounds.extents.z);
        maxZ = (groundSize.bounds.center.z + groundSize.bounds.extents.z);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful) {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        if (targetIndex >= path.Length) {
            targetIndex = 0;
            path = new Vector3[0];
            yield break;
        }

        targetIndex = 0;
        Vector3 currentWaypoint = path[0];
        Vector3 targetDir = currentWaypoint - this.transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;

                if (targetIndex >= path.Length) {
                    targetIndex = 0;
                    path = new Vector3[0];
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(this.transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null) {
            for (int i = targetIndex; i < path.Length; i++) {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex) {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}