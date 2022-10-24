using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    float speed = 2.0f;
    Rigidbody rigidbody;
    Renderer renderer;
    float maxSpeedRatio = 1.3f;
    [SerializeField]
    private GameObject mainMenuCanvas;
    private string startingMaterial = "Materials/DefaultMaterial_normal";
    private int startingMass = 10;
    private Vector3 startingPosition; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        renderer.material = LoadResourceAsMaterial(startingMaterial);
        rigidbody.mass = startingMass;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            rigidbody.mass++;
            Debug.Log("Mass is " + rigidbody.mass + "\n");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            rigidbody.mass--;
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
            mainMenuCanvas.GetComponent<MainMenuController>().PauseGame();
        }
        if(rigidbody.velocity.y < -1 && PinsController.score < 10){
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.position = startingPosition;
            transform.localPosition = startingPosition;
        }
    }
            
    public void OnDropDownChanged(Dropdown dropDown)
    {
        if (dropDown.value == 0){
            startingMaterial = "Materials/DefaultMaterial_normal";
        }
        else if (dropDown.value == 1){
            startingMaterial = "Materials/DefaultMaterial_roughness";
        }
        else if (dropDown.value == 2){
            startingMaterial = "Materials/DefaultMaterial_metallic";
        }
    }

    public void OnMassInputChanged(InputField inputField)
    {
        startingMass = int.Parse(inputField.text);
    }

    Material LoadResourceAsMaterial(string resourcePath){
        return Resources.Load(resourcePath, typeof(Material)) as Material;
    }
}
