using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NormalCharacter : Character<Attribute>
{
    public NormalCharacter()
    {
        Attributes = new NormalAttributes();
    }
}
