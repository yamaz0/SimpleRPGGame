using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character<T> where T : Attribute
{
    [SerializeField]
    private AttributesBase<T> attributes;
    [SerializeField]
    private List<int> knownSpellsId;

    public AttributesBase<T> Attributes { get => attributes; set => attributes = value; }
    public List<int> KnownSpellsId { get => knownSpellsId; set => knownSpellsId = value; }

    public void AddSpell(int id)
    {
        if(KnownSpellsId.Contains(id) == false)
        {
            KnownSpellsId.Add(id);
        }
    }

    public List<Attribute> GetAttributes()
    {
        return Attributes.GetAttributes();
    }
}