using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFireController : MonoBehaviour
{
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
            Debug.Log("Game Over!");
            Time.timeScale = 0;
            other.gameObject.SetActive(false);
        }
    }
}
