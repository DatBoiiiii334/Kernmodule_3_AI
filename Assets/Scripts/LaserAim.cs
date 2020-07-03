using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAim : MonoBehaviour
{

    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.collider) {
                _lineRenderer.SetPosition(1, new Vector3(0,0,hit.distance));
            }
            else {
                _lineRenderer.SetPosition(1, transform.forward * Mathf.Infinity);
            }
        }
    }
}
