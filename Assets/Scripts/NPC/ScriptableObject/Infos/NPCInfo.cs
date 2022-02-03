using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCInfo : IIdable, INameable
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
}