using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public QuestInfo QuestInfo { get; set; }
    public QuestTask CurrentTask { get; set; }
    public int CurrentTaskNumber { get; set; }

    public Quest(QuestInfo info, int currentTaskNumber = 0)
    {
        QuestInfo = info;
        CurrentTaskNumber = currentTaskNumber;
        CurrentTask = QuestInfo.GetQuestTask(CurrentTaskNumber);
        CurrentTask.Init(QuestInfo.Id);
        Debug.Log($"StartQuest id:{info.Id}");
    }

    public void UpdateQuest()
    {
        CurrentTaskNumber++;
        CurrentTask.End(QuestInfo.Id);
        QuestTask questTask = QuestInfo.GetQuestTask(CurrentTaskNumber);
        if (questTask == null)
        {
            //finish quest
            Debug.Log("finished quest");
        }
        else
        {
            CurrentTask = questTask;
            CurrentTask.Init(QuestInfo.Id);
            // CurrentTask.Init();
            //updateUIorSomething onQuestUpdated(CurrentTask);
            Debug.Log("Update quest");
        }
    }
}
