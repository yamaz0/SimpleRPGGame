using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private ItemsManager.ItemType itemType;

    public string ItemName { get => itemName; set => itemName = value; }
    public int Id { get => id; set => id = value; }
    public ItemsManager.ItemType ItemType { get => itemType; set => itemType = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    private void OnEnable()
        {
            //  hideFlags = HideFlags.HideAndDontSave;
        }
        protected void InitBase(int id, string name, Sprite sprite)
        {
            Id = id;
            ItemName = name;
            icon = sprite;
        }
    }