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
 [MenuItem("DoSomething/asdasd")]
    static void asdasd()
    {
        Progress progres = Player.Instance.Character.Attributes.Attributes[1].progres;
        Debug.Log(progres.GetProgressPercent());
        progres.AddProgress(1);
        Debug.Log(progres.GetProgressPercent());
    }

}
