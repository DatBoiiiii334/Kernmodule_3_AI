using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;


public class BB_WayPointSpawner : MonoBehaviour
{
    private Renderer groundSize;
    private Vector3 NewPos;
    private float minX, maxX, minZ, maxZ;

    public GameObject ground;


    private void Awake()
    {
        groundSize = ground.GetComponent<Renderer>();
        SpawnAtRandom_Check();
    }

    protected void SpawnAtRandom_Check()
    {
        groundSize = ground.GetComponent<Renderer>();

        if (groundSize == null) {
            Debug.LogError("NO RENDERER FOUND IN GROUND!!!!");
        }
        minX = (groundSize.bounds.center.x - groundSize.bounds.extents.x);
        maxX = (groundSize.bounds.center.x + groundSize.bounds.extents.x);
        minZ = (groundSize.bounds.center.z - groundSize.bounds.extents.z);
        maxZ = (groundSize.bounds.center.z + groundSize.bounds.extents.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost") {
            NewRoute(gameObject);
        }

        if (other.tag == "wall") {
            NewRoute(gameObject);
        }
    }

    public void NewRoute(GameObject ObjectToSpawn)
    {
        NewPos.x = Random.Range(minX, maxX);
        NewPos.z = Random.Range(minZ, maxZ);
        NewPos.y = gameObject.transform.position.y;
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = NewPos;
    }
}

