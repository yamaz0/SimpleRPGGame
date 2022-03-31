using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private GameInputsController gameInputController;
    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> ShowInventoryDelegate;
    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> ShowStatsDelegate;
    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> ShowAbilitiesDelegate;



    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();

        ShowInventoryDelegate = delegate (UnityEngine.InputSystem.InputAction.CallbackContext x) { WindowManager.Instance.ShowInventory(); };
        ShowStatsDelegate = delegate (UnityEngine.InputSystem.InputAction.CallbackContext x) { WindowManager.Instance.ShowStats(); };
        ShowAbilitiesDelegate = delegate (UnityEngine.InputSystem.InputAction.CallbackContext x) { WindowManager.Instance.ShowAbilities(); };
    }

    private void OnEnable()
    {
        gameInputController.Enable();
        gameInputController.Player.Inventory.started += ShowInventoryDelegate;
        gameInputController.Player.CharacterStats.started += ShowStatsDelegate;
        gameInputController.Player.CharacterAbilities.started += ShowAbilitiesDelegate;
    }

    private void OnDisable()
    {
        gameInputController.Player.Inventory.started -= ShowInventoryDelegate;
        gameInputController.Player.CharacterStats.started -= ShowStatsDelegate;
        gameInputController.Player.CharacterAbilities.started -= ShowAbilitiesDelegate;
        gameInputController.Disable();
    }
}
