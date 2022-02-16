using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SideQuestInfo : QuestInfo
{
    [SerializeReference]
    List<QuestTask> tasks = new List<QuestTask>();

    public List<QuestTask> Tasks { get => tasks; set => tasks = value; }
}
