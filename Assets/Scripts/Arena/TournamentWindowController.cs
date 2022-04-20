using System.Collections.Generic;
using UnityEngine;

public class TournamentWindowController : Window
{
    [SerializeField]
    private CharacterInfoUI randomCharacterUI;

    [SerializeField]
    List<Enemy> enemies = new List<Enemy>(6);

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        randomCharacterUI.Init(enemies[0].Character);
    }
}
