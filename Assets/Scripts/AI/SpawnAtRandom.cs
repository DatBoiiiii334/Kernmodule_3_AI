using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtRandom : MonoBehaviour
{
    private Renderer groundSize;

    protected Vector3 NewPos;
    protected float minX, maxX, minZ, maxZ;

    public GameObject ground;

    protected void SpawnAtRandom_Check()
    {
        groundSize = ground.GetComponent<Renderer>();

        if (groundSize == null) {
            Debug.LogError("NO RENDERER FOUND IN GHOST!!!!");
        }

        minX = (groundSize.bounds.center.x - groundSize.bounds.extents.x);
        maxX = (groundSize.bounds.center.x + groundSize.bounds.extents.x);
        minZ = (groundSize.bounds.center.z - groundSize.bounds.extents.z);
        maxZ = (groundSize.bounds.center.z + groundSize.bounds.extents.z);
    }

    public void NewRoute(GameObject ObjectToSpawn)
    {
        NewPos.x = Random.Range(minX, maxX);
        NewPos.z = Random.Range(minZ, maxZ);
        NewPos.y = transform.position.y;
        //Debug.Log("Changing pos");
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = NewPos;
    }
}
