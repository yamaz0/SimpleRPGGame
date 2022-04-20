using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Character character;

    public Character Character { get => character; set => character = value; }

    private void Awake()
    {
        // Character = RandomCharacter.CreateRandomCharacterBalancedToCharacter(Player.Instance.Character);
        Character.Initialize();
    }

}
