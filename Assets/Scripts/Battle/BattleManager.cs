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

    public void StartBattle<S, T>(Character<S> characterFirst, Character<T> characterSecound) where T : Attribute where S : Attribute
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
        if (Input.GetKeyDown(KeyCode.T))
            duelController.DoTurn();
    }
}
