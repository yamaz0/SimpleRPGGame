using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes
{
    [SerializeField]
    private Attribute knowledge;
    [SerializeField]
    private Attribute concetration;
    [SerializeField]
    // private Attribute blablalba;

    public Attribute Knowledge { get => knowledge; set => knowledge = value; }
    public Attribute Concetration { get => concetration; set => concetration = value; }
    // public Attribute Blablalba { get => blablalba; set => blablalba = value; }

    public void AddAttributeProgress(MagicAttributes attribute, float value)
    {
        switch (attribute)
        {
            case MagicAttributes.KNOWLEDGE:
            Knowledge.AddProgress(value);
                break;
            case MagicAttributes.CONCETRATION:
            Concetration.AddProgress(value);
                break;
            default:
            Debug.LogError("ATRIBUTE NOT EXIST");
            break;
        }
    }
    public enum MagicAttributes
    {
        KNOWLEDGE,
        CONCETRATION
    }
}