﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Character character;

    public Character Character { get => character; set => character = value; }



    //to dać do klasy ktora bedzie obslugiwac walke
    public void OnUpdate()
    {
        // for (int i = SpellEffects.Count - 1; i >= 0 ; i--)
        // {
        //     Player player = Player.Instance;
        //     SpellEffects[i].Execute(player, this);

        //     if(SpellEffects[i].CheckDuration() == true)
        //     {
        //         SpellEffects.RemoveAt(i);
        //     }
        // }
    }
}
