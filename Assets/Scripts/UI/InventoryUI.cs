using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();
    private List<GameObject> objects;
    public Button textTemplate;
    public Transform content;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Initialize();
    }
    public void Initialize()
    {
        List<int> itemsIds = Player.Instance.Character.Inventory.ItemsIds;
        ItemList.Clear();

        for (int i = 0; i < itemsIds.Count; i++)
        {
            AddItem(itemsIds[i]);
            Button tMP_Text = GameObject.Instantiate(textTemplate, content);
            tMP_Text.image.sprite = ItemList[i].Icon;
            tMP_Text.gameObject.SetActive(true);
            ItemList[i].Use();
        }
    }

    private void AddItem(int id)
    {
        // ItemsManager itemsManager = ItemsManager.Instance;
        ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(id);
        Item item = itemInfo.CreateItem();
        ItemList.Add(item);
    }
}
