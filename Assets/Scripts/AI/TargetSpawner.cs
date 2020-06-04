using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    protected float minX, maxX, minZ, maxZ;
    protected Renderer groundSize;

    protected Vector3 NewPos;
    public GameObject ground, targetBody, player, spawn;
    public Transform target;

    private void Awake()
    {
        groundSize = ground.GetComponent<Renderer>();
    }
}
