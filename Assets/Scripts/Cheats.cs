using System.Collections;
using System.Collections.Generic;
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

 [MenuItem("DoSomething/AddItemTest")]
    static void AddItem()
    {
        Player.Instance.Inventory.AddItem(ItemsManager.ItemType.BOOK, 0);
    }

 [MenuItem("DoSomething/TimeCouting")]
    static void TimeCouting()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        System.TimeSpan t=new System.TimeSpan();
            ItemsManager instance = ItemsManager.Instance;



        t= new System.TimeSpan();
        for (int i = 0; i < 1; i++)
        {
            sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Start();

            BookItem item2 = instance.CreateBookItem(0);

            sw.Stop();
            t+=sw.Elapsed;
        }
        Debug.Log("Elapsed2="+t);
    }

}


