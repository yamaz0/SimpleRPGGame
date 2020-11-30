using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attributes", menuName = "ScriptableObjects/Attributes")]
public class AttributesScriptableObject : ScriptableObject
{
    private static AttributesScriptableObject instance;

    [SerializeField]
    private List<AttributeInfo> attributes;

    public static AttributesScriptableObject Instance { get { return instance; } }

    public List<AttributeInfo> Attributes { get => attributes; set => attributes = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<AttributesScriptableObject>("")[0];
    }

    public AttributesScriptableObject()
    {
        instance = this;
    }

    public AttributeInfo GetAttributeInfoById(int id)
    {
        foreach (AttributeInfo nameInfo in Attributes)
        {
            if (nameInfo.Id == id)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public AttributeInfo GetAttributeInfoByName(string name)
    {
        foreach (AttributeInfo nameInfo in Attributes)
        {
            if (nameInfo.Name == name)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public enum MagicAttributes
    {
        KNOWLEDGE = 0,
        CONCETRATION=1,
        WILL=2,
        MANA=3
    }

    [System.Serializable]
    public class AttributeInfo
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int id;
        [SerializeField]
        private MagicAttributes magicAttributes;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public MagicAttributes MagicAttributes { get => magicAttributes; set => magicAttributes = value; }
    }
}
