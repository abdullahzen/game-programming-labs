using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinsController : MonoBehaviour
{
    public static int score = -10;
    private static List<string> collided = new List<string>();
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject VictoryCanvas;
    // Start is called before the first frame update
    void Start()
    {
        score = -10;
        collided = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 10){
            VictoryCanvas.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other){
        if ((other.gameObject.name == "Floor" || other.gameObject.name.Contains("ball") || other.gameObject.name.Contains("Pin")) && !collided.Contains(this.gameObject.name)){
            score++;
            scoreText.text = "Score: " + score;
            if (score > 0){
                collided.Add(this.gameObject.name);
            } 
        }
    }
}
