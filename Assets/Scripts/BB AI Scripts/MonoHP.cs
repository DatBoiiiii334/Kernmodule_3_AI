using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHP : MonoBehaviour, Idamagable, IRageble
{
    public int health;
    public bool IsRaging;
    public int damageToGive;
    public float RageTimer;
    public float DeathTimer;
    public string[] targetName;
    

    private float OldRageTimer;

    void Start()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(string _target in targetName) {
            if (collision.collider.tag == _target) {
                collision.collider.GetComponent<Idamagable>().GiveDamage(damageToGive);
            }
        }

        if (health <= 0) {
            if (collision.collider.tag == "Spawn") {
                
            }
        }
    }

    public void GiveDamage(int damage)
    {
        if(IsRaging == false) {
            health -= damage;
        }
    }

    public void Rage(bool startRaging)
    {
        IsRaging = startRaging;
    }
}
