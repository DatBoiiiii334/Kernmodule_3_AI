using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ghost" || collision.collider.tag == "Player") {
            collision.collider.GetComponent<Idamagable>().GiveDamage(10);
        }
    }
}
