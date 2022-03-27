using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameInputsController gameInputController;

    public static bool GamePause { get; private set; }

    private void OnEnable()
    {
        gameInputController.Enable();
        gameInputController.Game.Pause.started += _ => PauseGame(!GamePause);
    }

    private void OnDisable()
    {
        gameInputController.Game.Pause.started -= _ => PauseGame(!GamePause);
        gameInputController.Disable();
    }

    public void PauseGame(bool state)
    {
        if (state == true)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        GamePause = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void ResumeGame()
    {
        GamePause = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
    }

    public void SetPlayerCanMove(bool state)
    {
        Player.Instance.CanMove = state;
    }
}