using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageFruit : MonoBehaviour
{
    public string[] mytags;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in mytags) {
            if (collision.collider.tag == tag) {
                collision.collider.GetComponent<IRageble>().Rage(true);
                transform.gameObject.SetActive(false);
            }
        }

        if (collision.collider.tag == "wall") {
            transform.gameObject.SetActive(false);
        }
    }
}
