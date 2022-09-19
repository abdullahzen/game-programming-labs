using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    float force;
    Animator animator;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        force = 0f;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            animator.enabled = true;
            animator.Play("poolstick_pull_back");
        }
        if (Input.GetKey(KeyCode.Space)){
            Debug.Log("Force is now at " + force);
            force++;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            animator.Play("poolstick_push_forward");
        } 
    }

    void ReleaseStick(){
        GameObject ball = GameObject.Find("Ball Clube");
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(new Vector3(-1f, 0f, 0f) * force, ForceMode.Impulse);
    }
}
