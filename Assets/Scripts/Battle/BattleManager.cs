using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]
    private GameInputsController gameInputController;

    public Player player;
    public Enemy enemy;

    [SerializeField]
    private DuelController duelControllerPrefab;

    [SerializeField]
    private DuelController duelController;
    public bool walka;
    public void StartBattle(Character characterFirst, Character characterSecound)
    {
        duelController = Instantiate(duelControllerPrefab);
        duelController.Initialize(characterFirst, characterSecound);
    }
    protected override void Initialize()
    {
        base.Initialize();
        gameInputController= new GameInputsController();
        gameInputController.Player.BattleTets.started += _ => StartBattle(player.Character, enemy.Character);
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Player.BattleTets.started -= _ => StartBattle(player.Character, enemy.Character);
        gameInputController.Disable();
    }

    private void Update()
    {
        if (walka)
            duelController.DoTurn();
    }
}
