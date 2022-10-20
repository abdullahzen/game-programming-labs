using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float speed = 2.0f;
    Rigidbody rigidbody;
    Renderer renderer;
    float maxSpeedRatio = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
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
            // 12 is a constant multiplier. (it can be any value, this is used to keep things in perspective in terms of physics)
            Vector3 forwardForce = new Vector3(0f,0f, -speed * 12);
            rigidbody.AddForce(forwardForce, ForceMode.Impulse);
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
}
