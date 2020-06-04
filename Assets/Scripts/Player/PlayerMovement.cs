using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody myRb;
    public float speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 Up = new Vector3(0, 0, speed) * Time.deltaTime;
            myRb.MovePosition(transform.position + Up);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 Left = new Vector3(-speed, 0, 0) * Time.deltaTime;
            myRb.MovePosition(transform.position + Left);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 Right = new Vector3(speed, 0, 0) * Time.deltaTime;
            myRb.MovePosition(transform.position + Right);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 Down = new Vector3(0, 0, -speed) * Time.deltaTime;
            myRb.MovePosition(transform.position + Down);
        }
    }
}
