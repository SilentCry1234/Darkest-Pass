using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Header("Animador")]
    [Space]
    public Animator settingsAnim;

    [Header("Game Object")]
    [Space]
    public GameObject Pause; 
    public GameObject Player;
    public GameObject camara_UI;
    public GameObject PlayerImage;
    public GameObject BGvida;
    public GameObject BGui;
    public GameObject Gameover;
    public GameObject fireStone;

    void Start()
    {
        Player = Movmiento_Alec.instance.gameObject;
        camara_UI = Camara_UI.instance.gameObject;
        PlayerImage = Player_Image.instance.gameObject;
        BGvida = BG_Vida.instance.gameObject;
        BGui = BG_UI.instance.gameObject;
        fireStone = FireStone.instance.gameObject; 

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            AudioManager.instance.backgroundMusic.Stop();
            Player.SetActive(false);
            camara_UI.SetActive(false);
            PlayerImage.SetActive(false);
            BGvida.SetActive(false);
            BGui.SetActive(false);
            fireStone.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
            camara_UI.SetActive(true);
            PlayerImage.SetActive(true);
            BGvida.SetActive(true);
            BGui.SetActive(true);
            fireStone.SetActive(true);
        }

        Time.timeScale = 1; 
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); 
        PauseMenu.instance.pauseMenu.SetActive(false); 
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Closed"); 
    }

    public void GoToMainMenu()
    {
        //Debug.Log("Vuelvo al Menu principal"); 
        Gameover.SetActive(false);
        PauseMenu.instance.pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ShowSettings()
    {
        settingsAnim.SetBool("ShowSettings", true); 
    }

    public void HidSettings()
    {
        settingsAnim.SetBool("ShowSettings", false);
    }
}
