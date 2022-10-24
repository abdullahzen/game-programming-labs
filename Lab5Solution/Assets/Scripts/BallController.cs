using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float speed = 5.0f;
    Rigidbody rigidbody;
    public int health = 100;
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
        if (health <= 0){
            Debug.Log("Ball health reached 0. Ball is dead.");
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
