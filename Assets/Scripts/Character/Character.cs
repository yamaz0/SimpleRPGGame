using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public  class Character
{
    [SerializeField]
    private Attributes attributes;
    [SerializeField]
    private List<int> knownSpellsId;

    public Attributes Attributes { get => attributes; set => attributes = value; }
    public List<int> KnownSpellsId { get => knownSpellsId; set => knownSpellsId = value; }

    public void AddSpell(int id)
    {
        if(KnownSpellsId.Contains(id) == false)
        {
            KnownSpellsId.Add(id);
        }
    }

    public void CopyCharacter(Character characterCopy)
    {
        for (int i = 0; i < Attributes.AttributesList.Count; i++)
        {
            Attributes.AttributesList[i].SetLevel(characterCopy.Attributes.AttributesList[i].Level);
        }

        KnownSpellsId = new List<int>();
        KnownSpellsId.AddRange(characterCopy.KnownSpellsId);
    }
}