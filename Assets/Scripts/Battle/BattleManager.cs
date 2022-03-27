using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]
    private GameInputsController gameInputController;
    [SerializeField]
    private float timeFlow = 1f;

    public Player player;
    public Enemy enemy;

    [SerializeField]
    private GameObject battleGameObject;
    [SerializeField]
    private GameObject gameGameObject;
    [SerializeField]
    private DuelController duelControllerPrefab;

    private DuelController DuelController { get; set; }
    public bool walka;

    public float TimeFlow { get => timeFlow; set => timeFlow = value; }
    public float Timer { get; set; }

    public void StartBattle(Character characterFirst, Character characterSecound)
    {
        battleGameObject.SetActive(true);
        gameGameObject.SetActive(false);
        walka = true;

        DuelController = Instantiate(duelControllerPrefab, battleGameObject.transform);
        DuelController.gameObject.SetActive(true);
        DuelController.transform.position = Player.Instance.gameObject.transform.position - new Vector3(0, 4, 0);
        // DuelController.Initialize(characterFirst, characterSecound);
        DuelController.Initialize(characterFirst, RandomCharacter.CreateRandomCharacterBalancedToCharacter(characterFirst));
    }
    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
        gameInputController.Player.BattleTets.started += _ => StartBattle(player.Character, enemy.Character);
        gameInputController.Player.walka.started += _ => walka = !walka;
    }

    public void BattleEnd(bool isPlayerWin)
    {
        battleGameObject.SetActive(false);
        gameGameObject.SetActive(true);
        walka = false;

        if (isPlayerWin == true)
        {
            PlayerWin();
        }
        else
        {
            PlayerLose();
        }
        // DestroyImmediate(DuelController.gameObject);
    }

    private static void PlayerLose()
    {
        float expToSub = Player.Instance.Character.Statistics.Exp.Value * 0.1f;
        Player.Instance.Character.Statistics.Exp.AddValue(-expToSub, true);
        //popup czy cos ze przegrana i ilosc odjetego expa
        PopUpManager.Instance.ShowEndBattlePopUp("LOSE", $"You are too weak. You lose {expToSub} experience.");
    }

    private static void PlayerWin()
    {
        Player.Instance.Character.Statistics.Exp.AddValue(100, true);
        switch (Player.Instance.Character.Style)
        {
            case FightStyle.OneHand:
                Player.Instance.Character.Statistics.OneHandedDamageBonus.AddValue(1, true);
                break;
            case FightStyle.TwoHand:
                Player.Instance.Character.Statistics.TwoHandedDamageBonus.AddValue(1, true);
                break;
            case FightStyle.DualWield:
                Player.Instance.Character.Statistics.DualWieldDamageBonus.AddValue(1, true);
                break;
            default:
                Debug.LogError("Style not exist!");
                return;
        }
        //popup czy cos ze wygrana z wygranym expem lub nagroda itemy cokolwiek
        PopUpManager.Instance.ShowEndBattlePopUp("WIN", $"You are very stronk. You get 100 experience.");
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
