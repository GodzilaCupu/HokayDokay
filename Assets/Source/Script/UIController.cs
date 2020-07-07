using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasMenu;
    public GameObject CanvasSetting;
    public GameObject CanvasMenu2;
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;

    [Header("Other")]
    public Audio_Manager audioManager;

    public ScoreGame scoreScript;

    public Puck puckScript;
    public PlayerController playerMovement;
    public AiScript aiScript;


    public void ShowSetiingMenu()
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasSetting.SetActive(true);
    }

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void PlayGameAI()
    {
        SceneManager.LoadScene(1);
    }


    public void PlayGameMP()
    {
        SceneManager.LoadScene(2);
    }

    public void PopupMenuController()
    {
        CanvasMenu.SetActive(true);
    }

    public void PopupMenu2Controller()
    {
        CanvasMenu2.SetActive(true);
    }

    public void PopupMenuBack2Controller()
    {
        CanvasMenu2.SetActive(false);
    }

}
