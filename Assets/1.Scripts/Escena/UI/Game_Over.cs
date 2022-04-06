using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    [Header("GameOver stats")]
    [Space]
    public GameObject GameOver; 
    public static Game_Over instance;

    [Header("Game Object")]
    [Space]
    public GameObject Player;
    public GameObject camara_UI;
    public GameObject PlayerImage;
    public GameObject BGvida;
    public GameObject BGui;
    public GameObject fireStone;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        Player      = Movmiento_Alec.instance.gameObject;
        camara_UI   = Camara_UI.instance.gameObject;
        PlayerImage = Player_Image.instance.gameObject;
        BGvida      = BG_Vida.instance.gameObject;
        BGui        = BG_UI.instance.gameObject;
        fireStone   = FireStone.instance.gameObject;

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
}
