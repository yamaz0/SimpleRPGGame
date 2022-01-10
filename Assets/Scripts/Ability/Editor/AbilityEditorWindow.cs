using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AbilityEditorWindow : EditorWindow
{
    enum State { None, Mod, Details }
    List<System.Type> effectTypes;
    AbilityInfo currentInfo;
    State state;

    [MenuItem("ProjektMagic/AbilityWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<AbilityEditorWindow>();
        window.titleContent = new GUIContent("AbilityWindow");
        window.Show();
    }
    private void OnEnable()
    {
        effectTypes = System.Reflection.Assembly.GetAssembly(typeof(TwoCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(TwoCharacterEffect))).ToList();

    }
    private void OnGUI()
    {
        List<AbilityInfo> abilities = AbilityScriptableObject.Instance.Abilities;
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
                foreach (var e in currentInfo.TwoCharacterEffects)
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
                foreach (var e in currentInfo.TwoCharacterEffects)
                {
                    e.ViewFields();
                }
            }
        }
    }


    private void EffectsButtons(AbilityInfo info)
    {
        GUILayout.Label("Effects");
        GUILayout.BeginHorizontal();
        foreach (var t in effectTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                info.TwoCharacterEffects.Add(System.Activator.CreateInstance(t) as TwoCharacterEffect);
            }
        }
        GUILayout.EndHorizontal();
    }
}