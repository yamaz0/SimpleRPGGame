using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<SlotInventory> objects = new List<SlotInventory>(10);
    public SlotInventory slotTemplate;
    public Transform content;

    public List<SlotInventory> Objects { get => objects; set => objects = value; }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.I))
    //         Initialize();
    // }

    private void Start()
    {
        Objects = new List<SlotInventory>();
        Player.Instance.Character.InventoryController.OnInventoryChanged += Refresh;
        Refresh(0);
    }
    private void OnDisable()
    {
        Player.Instance.Character.InventoryController.OnInventoryChanged -= Refresh;
    }

    public void Refresh(int zmiennaDoUsuniecia)
    {
        if (Objects.Count != 0)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                Destroy(Objects[i].gameObject);
            }
            Objects.Clear();
        }
        List<int> itemsIds = Player.Instance.Character.InventoryController.Inventory.ItemsId;

        for (int i = 0; i < itemsIds.Count; i++)
        {
            CreateNewSlot(itemsIds[i]);
        }
    }

    private void CreateNewSlot(int id)
    {
        Item item = CreateItem(id);

        SlotInventory slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

    private Item CreateItem(int id)
    {
        // ItemsManager itemsManager = ItemsManager.Instance;
        ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(id);
        return itemInfo.CreateItem();
    }
}