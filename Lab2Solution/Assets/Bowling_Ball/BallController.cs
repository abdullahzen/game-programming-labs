using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float speed = 2.0f;
    //Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        //Vector3 forwardForce = new Vector3(0f, 0f, -speed * 12);
        
        // Using an impulsive force on the rigidbody of the ball
        // This is usually useful if you want to control the force magnitude with some kind of mapped input
        
        //rigidbody.AddForce(forwardForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // Using transforms and a constant speed moving forward relative to the camera view
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Camera.main.transform);
    }
}
