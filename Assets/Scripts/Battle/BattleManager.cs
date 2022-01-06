using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{


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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartBattle(player.Character,enemy.Character);
        }
        if (walka)
            duelController.DoTurn();
    }
}
