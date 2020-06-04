﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : PlayerMovement, Idamagable, IRageble
{
    private float OldRageTime;
    private bool startRage;

    public int HP;
    public float RageTime;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        OldRageTime = RageTime;
    }

    void Update()
    {
        if (startRage == true) {
            RageTime -= Time.deltaTime;
        }

        if (RageTime <= 0) {
            startRage = false;
            RageTime = OldRageTime;
        }

        //if(HP <= 0) {

        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (startRage == true) {
            if (collision.collider.tag == "Ghost") {
                collision.collider.GetComponent<Idamagable>().GiveDamage(1);
            }
        //}
    }

    void Idamagable.GiveDamage(int damage)
    {
        HP -= damage;
    }

    public void Rage(bool startRaging)
    {
        startRage = startRaging;
    }
}