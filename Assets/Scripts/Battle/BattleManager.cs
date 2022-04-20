using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
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

    public void StartBattle(Character characterFirst, Character characterSecound, RuleBase rule)
    {
        battleGameObject.SetActive(true);
        gameGameObject.SetActive(false);
        walka = true;

        DuelController = Instantiate(duelControllerPrefab, battleGameObject.transform);
        DuelController.gameObject.SetActive(true);
        DuelController.transform.position = Player.Instance.gameObject.transform.position - new Vector3(0, 4, 0);
        DuelController.Initialize(characterFirst, characterSecound, rule);
        // DuelController.Initialize(characterFirst, RandomCharacter.CreateRandomCharacterBalancedToCharacter(characterFirst));
    }

    public void BattleEnd()
    {
        battleGameObject.SetActive(false);
        gameGameObject.SetActive(true);

        DestroyImmediate(DuelController.gameObject);
    }

    public void StopFight()
    {
        walka = false;
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
