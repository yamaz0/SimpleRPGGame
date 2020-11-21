using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]
    private Attributes attributes;

    [SerializeField]
    public Attributes Attributes { get => attributes; set => attributes = value; }

    public void KnowledgeAdd()
    {
        Attributes.AddAttributeProgress(Attributes.MagicAttributes.KNOWLEDGE, 10);
    }

    public void ConcetrationAdd()
    {
        Attributes.AddAttributeProgress(Attributes.MagicAttributes.CONCETRATION, 10);
    }

}
