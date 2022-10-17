using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float speed = 5.0f;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            rigidbody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rigidbody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.AddForce(Vector3.left * speed);
        }
    }
}
