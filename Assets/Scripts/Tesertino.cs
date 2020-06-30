using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesertino : MonoBehaviour
{
    public GameObject[] allHealingItems;
    public  GameObject mytarget;
    public float myHealth;

    private void Start()
    {
        allHealingItems = GameObject.FindGameObjectsWithTag("HealingItem");
    }

    private void Update()
    {
        SearchForHealing();
        if (myHealth <= 0) {
            Debug.Log(mytarget.name);
        } 
    }

    void SearchForHealing()
    {
        foreach (GameObject healingItem in allHealingItems) {
            
            float healingDistance = 1000000;
            float distance = Vector3.Distance(transform.position, healingItem.transform.position);
            if(!healingItem == false) {
                if(distance < healingDistance) {
                    healingDistance = distance;
                    mytarget = healingItem;
                }
            }

        }
    }
}
