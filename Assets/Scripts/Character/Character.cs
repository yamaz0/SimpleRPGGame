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

    public void CopyCharacter<T>(Character<T> characterCopy) where T : Attribute
    {
        for (int i = 0; i < Attributes.Attributes.Count; i++)
        {
            Attributes.Attributes[i].SetLevel(characterCopy.Attributes.Attributes[i].Level);
        }

        KnownSpellsId = new List<int>();
        KnownSpellsId.AddRange(characterCopy.KnownSpellsId);
    }
}