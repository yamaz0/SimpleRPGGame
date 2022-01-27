using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]
    private GameInputsController gameInputController;
    [SerializeField]
    private float timeFlow = 0.1f;

    public Player player;
    public Enemy enemy;

    [SerializeField]
    private GameObject battleGameObject;
    [SerializeField]
    private DuelController duelControllerPrefab;

    private DuelController DuelController { get; set; }
    public bool walka;

    public float TimeFlow { get => timeFlow; set => timeFlow = value; }
    public float Timer { get; set; }

    public void StartBattle(Character characterFirst, Character characterSecound)
    {
        battleGameObject.SetActive(true);

        DuelController = Instantiate(duelControllerPrefab, battleGameObject.transform);
        DuelController.gameObject.SetActive(true);
        DuelController.Initialize(characterFirst, characterSecound);
    }
    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
        gameInputController.Player.BattleTets.started += _ => StartBattle(player.Character, enemy.Character);
        gameInputController.Player.walka.started += _ => walka = !walka;
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Player.BattleTets.started -= _ => StartBattle(player.Character, enemy.Character);
        gameInputController.Player.walka.started -= _ => walka = !walka;
        gameInputController.Disable();
    }

    private void Update()
    {
        if (walka)
        {
            Timer -= Time.deltaTime;

            if (Timer < 0)
            {
                Timer = TimeFlow;
                DuelController.DoTurn();
            }
        }
    }
}
