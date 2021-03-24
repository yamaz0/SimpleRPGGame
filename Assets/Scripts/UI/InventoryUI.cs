using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    public TMPro.TMP_Text textTemplate;
    public Transform content;
private void Update() {
    if(Input.GetKeyDown(KeyCode.I))
    Initialize();
}
    public void Initialize()
    {
        List<(ItemsManager.ItemType itemType, int id)> itemsIds = Player.Instance.Inventory.ItemsIds;
        ItemList.Clear();

        for (int i = 0; i < itemsIds.Count; i++)
        {
            (ItemsManager.ItemType itemType, int id) = itemsIds[i];
            AddItem(itemType, id);
            TMPro.TMP_Text tMP_Text = GameObject.Instantiate(textTemplate, content);
            tMP_Text.text =  id.ToString();
            tMP_Text.gameObject.SetActive(true);
        }
    }

    private void AddItem(ItemsManager.ItemType itemType, int id)
    {
        ItemsManager itemsManager = ItemsManager.Instance;
        Item item = null;

        switch (itemType)
        {
            case ItemsManager.ItemType.OTHER:
                break;
            case ItemsManager.ItemType.USE:
                break;
            case ItemsManager.ItemType.INGREDIENT:
                break;
            case ItemsManager.ItemType.BOOK:
                item = itemsManager.CreateBookItem(id);
                break;
            case ItemsManager.ItemType.QUEST:
                item = itemsManager.CreateQuestItem(id);
                break;
            default:
                Debug.LogError("Item type incorrect!");
                return;
        }
        ItemList.Add(item);
    }
}
