using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ghost" || collision.collider.tag == "Player") {
            collision.collider.GetComponent<IGiveHp>().GiveHealth(10);
            gameObject.SetActive(false);
        }
    }
}
