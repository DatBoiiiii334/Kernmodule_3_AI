using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_Ghost : Unit, Idamagable, IRageble, IRescueAble
{
    private Vector3 NewPos;

    public GameObject player, spawn, target;
    public State myState;
    public int myHealth;
    public float RageTime { get; set; }
    public float IdleTime { get; set; }
    public float FleeTime { get; set; }

    public bool KillGhost;
    public bool KillPlayer;
    public bool RescueGhost;
    public bool GotRescuedGhost;
    public bool InFleeZone;

    protected Dictionary<string, State> myStateDictionary = new Dictionary<string, State>();

    protected virtual void Update()
    {
        if (myState != null) {
            myState.OnUpdate(this);
        }

        if (myHealth <= 0) {
            Debug.Log("I HAVE BEEN HIT");
            ChangeState("Flee");
            myHealth = 1;
        }

        //If the Waypoint of the ghost has turned it's self false then call on the NewRoute function
        if (!target.activeInHierarchy) {
            NewRoute();
        }
    }
     
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target) {
            NewRoute();
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Targetable") {
            collision.collider.GetComponent<Idamagable>().GiveDamage(1);
            collision.collider.GetComponent<Iconsumable>().Eat(true);
        }

        if (collision.collider.gameObject == spawn) {
            InFleeZone = true;
        }

        if (KillPlayer == true) {
            if (collision.collider.tag == "Player") {
                collision.collider.GetComponent<Idamagable>().GiveDamage(1);
            }
        }

        if (collision.collider.tag == "Ghost") {
            Debug.Log("Boo");
            if (KillGhost == true) {
                collision.collider.GetComponent<Idamagable>().GiveDamage(1);
            }
            else {
                collision.collider.GetComponent<IRescueAble>().Rescue(true);
            }
        }
    }

    public void NewRoute()
    {
        NewPos.x = Random.Range(minX, maxX);
        NewPos.z = Random.Range(minZ, maxZ);
        NewPos.y = 0.5f;
        target.SetActive(true);
        target.transform.position = NewPos;
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
    }

    public void ChangeState(string stateName)
    {
        if (myState != null) {
            myState.OnExit(this);
        }
        if (myStateDictionary.ContainsKey(stateName)) {
            myState = myStateDictionary[stateName];
            myState.OnEnter(this);
        }
    }

    public void GiveDamage(int damage)
    {
        if (KillPlayer == false) {
            Debug.Log(name + "Has been hit");
            myHealth = myHealth - damage;
        }
    }

    public void Rage(bool startRaging)
    {
        if (startRaging == true) {
            ChangeState("Rage");
        }
    }

    public void Rescue(bool GetUp)
    {
        GotRescuedGhost = GetUp;
    }
}
