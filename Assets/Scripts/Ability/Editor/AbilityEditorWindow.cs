using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AbilityEditorWindow : EditorWindow
{
    List<System.Type> types;
    AbilityInfo currentInfo;

    [MenuItem("ProjektMagic/AbilityWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<AbilityEditorWindow>();
        window.titleContent = new GUIContent("AbilityWindow");
        window.Show();
    }
    private void OnEnable()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(TwoCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(TwoCharacterEffect))).ToList();

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
                GUILayout.Label(a.Name);
                if (GUILayout.Button("MOD"))
                {
                    currentInfo = a;
                }
            }
        }
        else
        {
            if (GUILayout.Button("BACK"))
            {
                currentInfo = null;
            }
            EffectsButtons(currentInfo);
        }
    }

    private void EffectsButtons(AbilityInfo info)
    {
        GUILayout.Label("Effects");
        GUILayout.BeginHorizontal();
        foreach (var t in types)
        {
            if (GUILayout.Button(t.ToString()))
            {
                info.TwoCharacterEffects.Add(System.Activator.CreateInstance(t) as TwoCharacterEffect);
            }
        }
        GUILayout.EndHorizontal();
    }
}