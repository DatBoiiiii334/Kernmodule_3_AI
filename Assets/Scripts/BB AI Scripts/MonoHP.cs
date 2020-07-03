using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHP : MonoBehaviour, Idamagable, IRageble, IGiveHp
{
    public int health;
    public bool IsRaging;
    public int damageToGive;
    public float RageTimer;
    public float DeathTimer;
    public string[] targetName;


    private bool InSpawn;
    private float OldHealt;
    private float OldRageTimer;

    void Start()
    {
        OldHealt = health;
        OldRageTimer = RageTimer;
    }

    private void FixedUpdate()
    {
        if (IsRaging == true) {
            RageTimer -= 1 * Time.deltaTime;
        }
        if (RageTimer <= 0) {
            IsRaging = false;
            RageTimer = OldRageTimer;
        }

        if (InSpawn) {
            if (health < OldHealt) {
                health += 1 ;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(health > 0) {
            foreach (string _target in targetName) {
                if (collision.collider.tag == _target) {
                    collision.collider.GetComponent<Idamagable>().GiveDamage(damageToGive);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawn") {
            InSpawn = true;
        }
        else {
            InSpawn = false;
        }
    }

    public void GiveDamage(int damage)
    {
        if(IsRaging == false) {
            if(health > 0) {
                health -= damage;
            } 
        }
    }

    public void Rage(bool startRaging)
    {
        IsRaging = startRaging;
    }

    public void GiveHealth(int hp)
    {
        health += hp;
    }
}
