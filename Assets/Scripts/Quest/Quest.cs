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
    }
    public void UpdateQuest()
    {
        CurrentTaskNumber++;
        QuestTask questTask = QuestInfo.GetQuestTask(CurrentTaskNumber);
        if (questTask == null)
        {
            //finish quest
        }
        else
        {
            CurrentTask = questTask;
            // CurrentTask.Init();
            //updateUIorSomething onQuestUpdated(CurrentTask);
        }
    }
}
