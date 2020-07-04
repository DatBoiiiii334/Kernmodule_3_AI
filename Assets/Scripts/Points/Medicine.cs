using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
<<<<<<< Updated upstream
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ghost" || collision.collider.tag == "Player") {
            collision.collider.GetComponent<IGiveHp>().GiveHealth(10);
            gameObject.SetActive(false);
=======
    public string[] mytags;
    public int healing;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in mytags) {
            if (collision.collider.tag == tag) {
                collision.collider.GetComponent<IGiveHp>().GiveHealth(healing);
                transform.gameObject.SetActive(false);
            }
        }

        if (collision.collider.tag == "wall") {
            transform.gameObject.SetActive(false);
>>>>>>> Stashed changes
        }
    }
}
