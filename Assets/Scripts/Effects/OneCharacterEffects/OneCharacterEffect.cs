using UnityEngine;

[System.Serializable]
public class OneCharacterEffect : Effect
{
    public virtual void Execute(Character character) { }
    public virtual void Remove(Character character) { }
}
