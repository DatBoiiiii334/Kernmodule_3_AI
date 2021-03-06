﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : SpawnAtRandom
{
    private int currentAmountPoolObjects;
    private int counter;

    public static PoolSpawner spawnerInstance;
    public GameObject spawnableGameobject;
    public List<GameObject> pooledObjects;
    public int amountToSpawn;
    public bool shouldExpand = true;

    public void Start()
    {
        SpawnAtRandom_Check();
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToSpawn; i++) {
            GameObject obj = Instantiate(spawnableGameobject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        if (shouldExpand) {
            GameObject newObj = (GameObject)Instantiate(spawnableGameobject);
            newObj.SetActive(false);
            pooledObjects.Add(newObj);
            return newObj;
        }
        else {
            return null;
        }
    }

    public void Update()
    {
        currentAmountPoolObjects = pooledObjects.Count;
        CountDucksInScene();

        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnDuckWave(amountToSpawn);
        }

        if (counter == 0) {
            SpawnDuckWave(amountToSpawn);
        }
    }

    public void CountDucksInScene()
    {
        counter = currentAmountPoolObjects;
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                if (counter > 0) {
                    counter -= 1;
                }
            }
        }
    }

    public void SpawnDuckWave(int amount)
    {
        for (int i = 0; i < amount; i++) {
            GameObject Duck = GetPooledObject();
            if (Duck != null) {
                NewRoute(Duck);
                Duck.SetActive(true);
            }
        }
    }
}