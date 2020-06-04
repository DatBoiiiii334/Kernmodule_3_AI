using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageFruit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Ghost") {
            collision.collider.GetComponent<IRageble>().Rage(true);
            transform.gameObject.SetActive(false);
        }
    }
}
