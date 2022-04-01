using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AbilityEditorWindow : EditorWindow
{
    enum State { None, Mod, Details }
    List<System.Type> effectTypes;
    List<System.Type> oneCharacterEffectTypes;
    AbilityInfo currentInfo;
    State state;
    Vector2 scrollPos;

    [MenuItem("ProjektMagic/AbilityWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<AbilityEditorWindow>();
        window.titleContent = new GUIContent("AbilityWindow");
        window.Show();
    }
    private void OnEnable()
    {
        effectTypes = System.Reflection.Assembly.GetAssembly(typeof(TwoOponentBattleEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(TwoOponentBattleEffect))).ToList();
        oneCharacterEffectTypes = System.Reflection.Assembly.GetAssembly(typeof(OneCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OneCharacterEffect))).ToList();

    }
    private void OnGUI()
    {
        List<AbilityInfo> abilities = AbilityScriptableObject.Instance.GetAbilitiesList();

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height - 25));
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
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
                foreach (var e in currentInfo.TwoOponentBattleEffects)
                {
                    e.ViewInfo();
                }
            }
            else if (state == State.Mod)
            {
                EffectsButtons(currentInfo);
                GUILayout.Label("Id: " + currentInfo.Id.ToString());
                GUILayout.Label("Name: " + currentInfo.Name);
                GUILayout.Label("TwoCharacterEffects: ");
                foreach (var e in currentInfo.TwoOponentBattleEffects)
                {
                    e.ViewFields();
                }
            }

        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }


    private void EffectsButtons(AbilityInfo info)
    {
        GUILayout.Label("Battle Effects");
        GUILayout.BeginHorizontal();
        foreach (var t in effectTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                info.TwoOponentBattleEffects.Add(System.Activator.CreateInstance(t) as TwoOponentBattleEffect);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Character Effects");
        GUILayout.BeginHorizontal();
        foreach (var t in oneCharacterEffectTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                info.OneCharacterEffects.Add(System.Activator.CreateInstance(t) as OneCharacterEffect);
            }
        }
        GUILayout.EndHorizontal();
    }
}