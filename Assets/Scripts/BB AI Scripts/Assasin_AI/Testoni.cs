using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testoni : MonoBehaviour
{
    public GameObject muhTarget;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = gameObject.transform.TransformDirection(Vector3.forward) * 10;
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0.1f, 0), dir, out hit, 10)) {

            Debug.DrawRay(gameObject.transform.position, dir, Color.red);
            if (hit.collider.gameObject == muhTarget) {
                Debug.Log("Hello");
                Debug.DrawRay(gameObject.transform.position, dir, Color.red);
            }
        }
    }
}
