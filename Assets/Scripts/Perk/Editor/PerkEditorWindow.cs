using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PerkEditorWindow : EditorWindow
{
    enum State { None, Mod, Details }
    List<System.Type> effectTypes;
    PerkScriptableObject.PerkInfo currentInfo;
    State state;

    [MenuItem("ProjektMagic/PerkWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<PerkEditorWindow>();
        window.titleContent = new GUIContent("PerkWindow");
        window.Show();
    }
    private void OnEnable()
    {
        effectTypes = System.Reflection.Assembly.GetAssembly(typeof(OneCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OneCharacterEffect))).ToList();

    }
    private void OnGUI()
    {
        List<PerkScriptableObject.PerkInfo> abilities = PerkScriptableObject.Instance.Perks;
        if (currentInfo == null)
        {
            foreach (var a in abilities)
            {
                GUILayout.Box(a.Icon.texture, GUILayout.Width(100), GUILayout.Height(50));
                GUILayout.Label("Id: " + a.Id.ToString());
                GUILayout.Label("Name: " + a.Name);
                if (GUILayout.Button("Details"))
                {
                    currentInfo = a;
                    state = State.Details;
                }
                GUILayout.Label("Name: " + a.Name);
                if (GUILayout.Button("Mod"))
                {
                    currentInfo = a;
                    state = State.Mod;
                }
            }
        }
        else
        {
            if (GUILayout.Button("BACK"))
            {
                currentInfo = null;
                state = State.None;
                return;
            }

            if (state == State.Details)
            {

                GUILayout.Label("Id: " + currentInfo.Id.ToString());
                GUILayout.Label("Name: " + currentInfo.Name);
                GUILayout.Label("TwoCharacterEffects: ");
                foreach (var e in currentInfo.Efects)
                {
                    e.ViewInfo();
                }
            }
            else if(state == State.Mod)
            {
                EffectsButtons(currentInfo);
                GUILayout.Label("Id: " + currentInfo.Id.ToString());
                GUILayout.Label("Name: " + currentInfo.Name);
                GUILayout.Label("TwoCharacterEffects: ");
                foreach (var e in currentInfo.Efects)
                {
                    e.ViewFields();
                }
            }
        }
    }


    private void EffectsButtons(PerkScriptableObject.PerkInfo info)
    {
        GUILayout.Label("Effects");
        GUILayout.BeginHorizontal();
        foreach (var t in effectTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                info.Efects.Add(System.Activator.CreateInstance(t) as OneCharacterEffect);
            }
        }
        GUILayout.EndHorizontal();
    }
}