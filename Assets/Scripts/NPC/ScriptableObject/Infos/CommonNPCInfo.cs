using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonNPCInfo : NPCInfo
{
    [SerializeField]
    private List<string> texts;

    public List<string> Texts { get => texts; set => texts = value; }
}
