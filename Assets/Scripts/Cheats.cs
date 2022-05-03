#if UNITY_EDITOR
using System;
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

    public static string GetClassDetails(Type t, ref string searchPropertyName, string str = null)
    {
        // if (sList is null) sList = new List<string>();
        // if (str is null) str = t.Name;

        foreach (var propertyInfo in t.GetProperties())
        {
            if (propertyInfo.Name.Equals(searchPropertyName))
            {
                searchPropertyName = string.Empty;
                return searchPropertyName;
            }

            if (string.IsNullOrEmpty(str) == true)
                str = propertyInfo.Name;
            else
                str = $"{str}.{propertyInfo.Name}";

            if (propertyInfo.PropertyType.IsClass)
            {
                string v = GetClassDetails(propertyInfo.PropertyType, ref searchPropertyName, str);
                if (string.IsNullOrEmpty(v) == false)
                    str = $"{str}.{v}";

            }
            if (string.IsNullOrEmpty(searchPropertyName)) break;
            // sList.Add(str);
            str = "";
        }

        return str;
    }


    [MenuItem("DoSomething/test")]
    static void PrintRandomAtributesValues()
    {
WindowManager.Instance.ShowNotification("new Ability: super duper kozak rzecz!");
WindowManager.Instance.ShowNotification("new Ability: Kick!!");
WindowManager.Instance.ShowNotification("new Item: Super Magic Sword!");
WindowManager.Instance.ShowNotification("New Perk: Ssj5!");
    }

    [MenuItem("DoSomething/AddItems")]
    static void ChangeItems()
    {
        // foreach (ItemInfo item in ItemsScriptableObject.Instance.Objects)
        // {
        //     int lvl = 0;
        //     if (item is WeaponItemInfo wi)
        //     {
        //         if (wi.Attack < 15)
        //             lvl = 0;
        //         else if (wi.Attack < 30)
        //             lvl = 1;
        //         else if (wi.Attack < 45)
        //             lvl = 2;
        //         else if (wi.Attack < 60)
        //             lvl = 3;
        //         else
        //             lvl = 4;
        //     }
        //     else if (item is EquipItemInfo ei)
        //     {
        //         if (ei.Defense < 15)
        //             lvl = 0;
        //         else if (ei.Defense < 30)
        //             lvl = 1;
        //         else if (ei.Defense < 45)
        //             lvl = 2;
        //         else if (ei.Defense < 60)
        //             lvl = 3;
        //         else
        //             lvl = 4;
        //     }
        //     item.UnlockLevel = lvl;
        // }
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



#endif