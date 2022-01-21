using System;
using System.Collections;
using UnityEngine;
public interface IEffect
{
    void Execute(Character character);
}
public interface ITwoCharacterEffect
{
    void Execute(Opponent atacker, Opponent atacked);
}

[Serializable]
public class Effect
{
    [SerializeField]
    private string name;

    public string Name { get => name; set => name = value; }

    public virtual void ViewInfo()
    {
        GUILayout.Label("Name: " + Name.ToString());
    }
    public virtual void ViewFields()
    {
        Name = UnityEditor.EditorGUILayout.TextField("Name", Name);
    }

}