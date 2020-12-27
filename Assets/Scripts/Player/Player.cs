﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]
    private ProgressCharacter character;

    public ProgressCharacter Character { get => character; set => character = value; }

    public void LoadData()
    {
       SavePlayer.PlayerDeserialize(this);
    }

    public void SaveData()
    {
       SavePlayer.PlayerSerialize(this);
    }

    private void Start()
    {
        // LoadData();
    }

    public void KnowledgeAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.KNOWLEDGE, 10);
    }

    public void ConcetrationAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.CONCETRATION, 10);
    }
}
