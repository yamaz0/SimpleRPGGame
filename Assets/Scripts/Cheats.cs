﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Cheats : MonoBehaviour
{
 [MenuItem("DoSomething/LoadPlayer")]
    static void LoadPlayer()
    {
        Player.Instance.LoadData();
    }
 [MenuItem("DoSomething/SavePlayer")]
    static void SavePlayer()
    {
        Player.Instance.SaveData();
    }

public static string GetClassDetails(Type t,ref string searchPropertyName, string str = null )
{
    // if (sList is null) sList = new List<string>();
    // if (str is null) str = t.Name;

    foreach (var propertyInfo in t.GetProperties())
    {
        if(propertyInfo.Name.Equals(searchPropertyName))
        {
            searchPropertyName = string.Empty;
            return searchPropertyName;
        }

        if(string.IsNullOrEmpty(str) == true)
            str = propertyInfo.Name;
        else
            str = $"{str}.{propertyInfo.Name}";

        if (propertyInfo.PropertyType.IsClass)
        {
                string v = GetClassDetails(propertyInfo.PropertyType, ref searchPropertyName, str);
                if(string.IsNullOrEmpty(v) == false)
                    str = $"{str}.{v}";

        }
if(string.IsNullOrEmpty(searchPropertyName)) break;
        // sList.Add(str);
        str = "";
    }

    return str;
}

 [MenuItem("DoSomething/CollectQuestTask")]
    static void AddTask()
    {
        QuestInfo item = new QuestInfo();
        item.Tasks.Add(new CollectQuestTaskInfo());
        item.Tasks.Add(new InteractQuestTaskInfo());
        item.Tasks.Add(new CollectQuestTaskInfo());
        QuestScriptableObject.Instance.Objects.Add(item);

    }

 [MenuItem("DoSomething/AddTaskInteract")]
    static void AddTaskInteract()
    {
        QuestInfo item = new QuestInfo();
        item.Tasks.Add(new InteractQuestTaskInfo());
        item.Tasks.Add(new InteractQuestTaskInfo());
        item.Tasks.Add(new InteractQuestTaskInfo());
        QuestScriptableObject.Instance.Objects.Add(item);

    }

 [MenuItem("DoSomething/test")]
    static void PrintRandomAtributesValues()
    {
        // Player.Instance.Inventory.AddItem(ItemsManager.ItemType.BOOK, 0);
        for (int i = 0; i < 10; i++)
        {
        RandomCharacter.CreateRandomCharacterBalancedToCharacter(null);
        }

    }

 [MenuItem("DoSomething/TimeCouting")]
    static void TimeCouting()
    {
    //     System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    //     System.TimeSpan t=new System.TimeSpan();
    //     // ItemsManager instance = ItemsManager.Instance;
    //     List<ModificatorInfo> modyficatorsInfo = ModificatorsSO.Instance.ModyficatorsInfo;



    //     t = new System.TimeSpan();
    //     for (int i = 0; i < 10000; i++)
    //     {
    //         sw = System.Diagnostics.Stopwatch.StartNew();
    //         sw.Start();

    //     foreach (ModificatorInfo info in modyficatorsInfo)
    //     {
    //         Modificator propertyInfo = ModificatorsSO.GetModifier(Player.Instance.Character, info);
    //     }

    //         sw.Stop();
    //         t+=sw.Elapsed;
    //     }
    //     Debug.Log("Elapsed2="+t);
    }

}


