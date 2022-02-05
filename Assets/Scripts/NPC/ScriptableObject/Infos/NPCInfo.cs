using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;

    public Sprite Icon { get => icon; set => icon = value; }
}