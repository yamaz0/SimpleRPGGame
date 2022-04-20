using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTournament : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>(6);

    public int Progress { get; set; }

    public void Fight()
    {
        BattleManager.Instance.StartBattle(Player.Instance.Character, enemies[Player.Instance.ProgressLevel].Character, new TournamentRule());
    }
}
