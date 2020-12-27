using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressCharacter : Character<ProgressAttribute>
{
    public ProgressCharacter()
    {
        Attributes = new ProgressAttributes();
    }
}