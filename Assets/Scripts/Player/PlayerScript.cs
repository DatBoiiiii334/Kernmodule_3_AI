using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : PlayerMovement, Idamagable, IRageble
{
    private float OldRageTime;
    private bool IsInRage;
    public Material myShader;

    public int HP;
    public float RageTime;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        OldRageTime = RageTime;
        myShader.SetColor("_Color", Color.cyan);
    }

    void Update()
    {
        if (IsInRage == true) {
            RageTime -= Time.deltaTime;
            myShader.SetColor("_Color", Color.red);
        }
        else {
            myShader.SetColor("_Color", Color.cyan);
        }

        if (RageTime <= 0) {
            IsInRage = false;
            RageTime = OldRageTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            IsInRage = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsInRage == true) {
            if (collision.collider.tag == "Ghost") {
                Debug.Log(collision.collider.name + "Was hit by enraged ghost");
                collision.collider.GetComponent<Idamagable>().GiveDamage(10);
            }
        }
    }

    void Idamagable.GiveDamage(int damage)
    {
        if(IsInRage == false) {
            HP -= damage;
        }
    }

    public void Rage(bool startRaging)
    {
        IsInRage = startRaging;
    }
}
