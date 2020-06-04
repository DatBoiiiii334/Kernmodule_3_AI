using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForTag : MonoBehaviour
{
    public string TagName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagName) {
            gameObject.SetActive(false);
        }
    }
}
