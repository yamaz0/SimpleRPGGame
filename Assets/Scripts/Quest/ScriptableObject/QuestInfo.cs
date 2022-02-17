using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;

    [SerializeReference]
    List<QuestTask> tasks = new List<QuestTask>();

    public List<QuestTask> Tasks { get => tasks; set => tasks = value; }
}
