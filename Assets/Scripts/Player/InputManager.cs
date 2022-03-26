using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{    
    [SerializeField]
    private GameInputsController gameInputController;
    [SerializeField]
    private GameObject inventory;



    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
    }

    private void OnEnable()
    {
        gameInputController.Enable();
        gameInputController.Player.Inventory.started += _ => inventory.SetActive(!inventory.activeSelf);
    }

    private void OnDisable()
    {
        gameInputController.Player.Inventory.started -= _ => inventory.SetActive(!inventory.activeSelf);
        gameInputController.Disable();
    }
}
