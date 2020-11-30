﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCharacter : Character<ProgressAttribute>
{
    public PlayerCharacter()
    {
        Attributes = new ProgressAttributes();
    }
}
