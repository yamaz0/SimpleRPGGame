using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterWindowController : Window
{
    [SerializeField]
    private List<CharacterInfoUI> randomCharactersUIs = new List<CharacterInfoUI>(3);

    public void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            Character randomChar = RandomCharacter.CreateRandomCharacterBalancedToCharacter(Player.Instance.Character);
            randomCharactersUIs[i].Init(randomChar);
        }
    }
}
