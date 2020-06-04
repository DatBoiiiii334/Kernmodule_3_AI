using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageFruit : MonoBehaviour 
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<IRageble>().Rage(true);
        transform.gameObject.SetActive(false);
    }
}
