using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, Idamagable, IRageble
{
    private Rigidbody myRb;
    private float OriginalCanKillTimer;

    public float speed;
    public int HP;
    public bool CanKill;
    public float CanKillTimer;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        OriginalCanKillTimer = CanKillTimer;
    }

    void Update()
    {
        if (CanKill == true) {
            CanKillTimer -= 0.1f * Time.deltaTime;
        }

        if (CanKillTimer <= 0) {
            CanKill = false;
            CanKillTimer = OriginalCanKillTimer;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CanKill == true) {
            if (collision.collider.tag == "Ghost") {
                collision.collider.GetComponent<Idamagable>().GiveDamage(1);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 Up = new Vector3(0, 0, speed) * Time.deltaTime;
            myRb.MovePosition(transform.position + Up);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 Left = new Vector3(-speed, 0, 0) * Time.deltaTime;
            myRb.MovePosition(transform.position + Left);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 Right = new Vector3(speed, 0, 0) * Time.deltaTime;
            myRb.MovePosition(transform.position + Right);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 Down = new Vector3(0, 0, -speed) * Time.deltaTime;
            myRb.MovePosition(transform.position + Down);
        }
    }

    void Idamagable.GiveDamage(int damage)
    {
        HP -= damage;
    }

    public void Rage(bool startRaging)
    {
        if (startRaging == true) {
            CanKill = true;
        }
    }
}
