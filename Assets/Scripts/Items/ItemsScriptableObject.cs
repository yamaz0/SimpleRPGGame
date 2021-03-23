using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsScriptableObject")]
public abstract class ItemsScriptableObject<T,Y>: ScriptableObject
    where T: ItemsScriptableObject<T,Y>
    where Y: ItemsScriptableObject<T,Y>.ItemInfo
{
    private static T instance;

    [SerializeField]
    private List<Y> items;

    public static T Instance { get { return instance; } }

    public List<Y> Items { get => items; set => items = value; }

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        instance = Resources.LoadAll<T>("")[0];
    }

    public ItemsScriptableObject()
    {
        instance = (T)this;
    }

    public Y GetItemInfoById(int id)
    {
        foreach (Y nameInfo in Items)
        {
            if (nameInfo.Id == id)
            {
                return nameInfo;
            }
        }

        return null;
    }

    public Y GetItemInfoByName(string name)
    {
        foreach (Y nameInfo in Items)
        {
            if (nameInfo.Name == name)
            {
                return nameInfo;
            }
        }

        return null;
    }


    [System.Serializable]
    public abstract class ItemInfo
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int id;
        [SerializeField]
        private ItemsManager.ItemType itemType;//prawdopodobnie do wywalenia xd

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }
    }
}