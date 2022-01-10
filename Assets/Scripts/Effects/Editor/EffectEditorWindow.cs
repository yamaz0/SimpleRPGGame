using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EffectEditorWindow : EditorWindow
{
    [MenuItem("ProjektMagic/EffectEditor")]
    private static void ShowWindow()
    {
        EffectEditorWindow window = GetWindow<EffectEditorWindow>();
        window.titleContent = new GUIContent("EffectEditor");
        window.Show();
    }

    private void OnEnable()
    {
        
    }

    private void OnGUI()
    {
        
    }
}