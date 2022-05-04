using System.Collections.Generic;
using UnityEngine;

public class TournamentWindowController : Window
{
    [SerializeField]
    private CharacterInfoUI characterUI;

    [SerializeField]
    List<Enemy> enemies = new List<Enemy>(6);

    private void Start()
    {
        // Init();
    }

    public void Init()//TODO zmienic na scriptableobjecty
    {
        Enemy boss = Instantiate(enemies[Player.Instance.ProgressLevel]);
        Character character = boss.Character;
        characterUI.Init(character);
    }
}
