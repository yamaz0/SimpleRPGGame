using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SideQuestInfo : QuestInfo
{
    [SerializeField]
    List<QuestTask> tasks;
}
