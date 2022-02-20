using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTask
{
    public QuestTaskInfo questInfo { get; set; }

    public QuestTask(QuestTaskInfo info)
    {
        questInfo = info;
    }

    public virtual void Init(int questId)
    {

    }
    public virtual void End(int questId)
    {

    }
}