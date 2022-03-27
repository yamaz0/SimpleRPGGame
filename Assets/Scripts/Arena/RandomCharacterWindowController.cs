using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterWindowController : MonoBehaviour
{
    [SerializeField]
    private List<RandomCharacterUI> randomCharactersUIs = new List<RandomCharacterUI>(3);

    private void OnEnable()
    {
        for (int i = 0; i < 3; i++)
        {
            Character randomChar = RandomCharacter.CreateRandomCharacterBalancedToCharacter(Player.Instance.Character);
            randomCharactersUIs[i].Init(randomChar);
        }
    }
}
