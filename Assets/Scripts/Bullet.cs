using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public string[] mytags;
    public int damage;

>>>>>>> Stashed changes
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< Updated upstream
        if (collision.collider.tag == "Ghost" || collision.collider.tag == "Player") {
            collision.collider.GetComponent<Idamagable>().GiveDamage(10);
=======
        foreach (string tag in mytags) {
            if (collision.collider.tag == tag) {
                collision.collider.GetComponent<Idamagable>().GiveDamage(damage);
            }
        }

        if (collision.collider.tag == "wall") {
            Destroy(gameObject);
>>>>>>> Stashed changes
        }
    }
}
