using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    float force = 0f;
    Rigidbody rigidBody;
    Animator animator;
    AnimatorClipInfo[] animatorClipInfo;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            animator.enabled = true;
            animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
            AnimationClip clip = animatorClipInfo[0].clip;

        }
        if (Input.GetKey(KeyCode.Space)){
            force++;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            animator.Play("poolstick_release");
        }
        
    }

    void PoolStickRelease(){
        GameObject ball = GameObject.Find("Ball Clube");
        Rigidbody rigidbodyBall = ball.GetComponent<Rigidbody>();
        rigidbodyBall.AddForce(new Vector3(-1f,0f,0f) * force, ForceMode.Impulse);
    }
}
