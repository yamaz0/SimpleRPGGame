using System;
using System.Collections;
using UnityEngine;
public interface IEffect
{
    void Execute(Character character);
}
public interface ITwoCharacterEffect
{
    void Execute(Character atacker, Character atacked);
}

[Serializable]
public class Effect
{
    [SerializeField]
    private string name;
    [SerializeField]
    private bool isSingleUse;

    public string Name { get => name; set => name = value; }
    public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }

    public virtual void ViewInfo()
    {
        GUILayout.Label("Name: " + Name.ToString());
        GUILayout.Label("IsSingleUse: " + IsSingleUse.ToString());
    }
    public virtual void ViewFields()
    {
        Name = UnityEditor.EditorGUILayout.TextField("Name", Name);
        IsSingleUse = UnityEditor.EditorGUILayout.Toggle("IsSingleUse", IsSingleUse);
    }

}