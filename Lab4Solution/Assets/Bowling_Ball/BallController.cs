using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rigidbody;
    private Renderer renderer;
    private float maxSpeedRatio = 1.3f;
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hitClip;
    [SerializeField]
    private AudioClip rollClip;
    [SerializeField]
    private AudioClip strikeClip;
    bool strike = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        animator = this.transform.parent.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            rigidbody.mass++;
            CheckColorChange();
            Debug.Log("Mass is " + rigidbody.mass + "\n");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            rigidbody.mass--;
            CheckColorChange();
            Debug.Log("Mass is " + rigidbody.mass + "\n");
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            animator.enabled = true;
            animator.Play("arm_pull_back");
        }
        // Using transforms and a constant speed moving forward relative to the camera view
        if (Input.GetKey(KeyCode.Space)){
            if (rigidbody.mass > 20){
                maxSpeedRatio = 1.1f;
            }
            var maxSpeed = rigidbody.mass * maxSpeedRatio;
            if (speed <= maxSpeed){
                speed++;
            }
            Debug.Log("Max speed is " + maxSpeed + "\n");
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            Debug.Log("Speed is " + speed + "\n");
            animator.Play("arm_push_forward");
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            Restart(); 
        }
    }

    void CheckColorChange()
    {
        if (rigidbody.mass < 10){
            renderer.material = LoadResourceAsMaterial("Materials/DefaultMaterial_normal");
        }
        else if (rigidbody.mass < 15){
            renderer.material = LoadResourceAsMaterial("Materials/DefaultMaterial_roughness");
        }
        else if (rigidbody.mass >= 20){
            renderer.material = LoadResourceAsMaterial("Materials/DefaultMaterial_metallic");
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.name == "Floor"){
            audioSource.PlayOneShot(hitClip);
        } else if (other.gameObject.name.Contains("Pin")){
            if (!strike){
                audioSource.PlayOneShot(strikeClip);
                strike = true;
            }
        }
    }

    void OnCollisionStay(Collision other){
        if (other.gameObject.name == "Floor"){
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(rollClip);
            }
        }
    }
}
