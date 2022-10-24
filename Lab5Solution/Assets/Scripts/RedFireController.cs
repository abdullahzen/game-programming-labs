using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFireController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip burningClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.name == "model"){
            BallController ballController = other.gameObject.GetComponent<BallController>();
            if (ballController != null && ballController.health > 0){
                ballController.health--;
                Debug.Log("Ball Heatlh is now " + ballController.health);
                if (ballController.health == 0){
                    audioSource.Stop();
                }
            }
            if (!audioSource.isPlaying){
                audioSource.PlayOneShot(burningClip);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "model"){
            if (audioSource.isPlaying){
                audioSource.Stop();
            }
        }
    }
}
