using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject BowlingBall;
    [SerializeField]
    private GameObject ScoreCanvas;
    [SerializeField]
    private GameObject StartGameButton;
    [SerializeField]
    private GameObject ResumeGameButton;
    [SerializeField]
    private GameObject OptionsButton;
    [SerializeField]
    private GameObject QuitButton;
    [SerializeField]
    private GameObject OptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0){
            this.PauseGame();
        }
        
    }

    public void StartGame(){
        BowlingBall.SetActive(true);
        ScoreCanvas.SetActive(true);
        StartGameButton.SetActive(false);
        OptionsButton.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void PauseGame(){
        ResumeGameButton.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void ShowOptions(){
        OptionsPanel.SetActive(true);
    }

    public void QuitGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackOptions(){
        OptionsPanel.SetActive(false);
    }
}
