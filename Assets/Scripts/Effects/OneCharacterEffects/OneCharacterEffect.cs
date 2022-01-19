using UnityEngine;

[System.Serializable]
public class OneCharacterEffect : Effect
{
    [SerializeField]
    private bool isPersistent;

    public bool IsPersistent { get => isPersistent; set => isPersistent = value; }

    public virtual void Execute(Character character) { }
    public virtual void Remove(Character character) { }
}
